using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.EngineControl;
using System.Linq;

namespace OutAndRefTutorial
{
    /// <summary>
    /// This class records weapon telemetry and engine chamber pressure information to
    /// send back to the launching vehicle
    /// </summary>
    public static class EngineTelemetryClass {



        public static TelemetryInformationClass GenerateInitialEngineTelemetry()
        {
            TelemetryInformationClass TIC = new TelemetryInformationClass();
            TIC.Altitude = FakeFlightTelemetry.GenerateRandomStartingAltitude();
            TIC.Action = STABenums.ActionTaken.NoAction; ///Just launched so no action
            TIC.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            TIC.AveragePsi = 0;
            TIC.ElapsedFlightTime = 0;
            TIC.EngagementTime = 0;
            TIC.PsiAfterCalibration = 0;
            TIC.TimeStamp = DateTime.Now;
            TIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;
            TIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();
            (STABenums.FaultStatus Fault, STABenums.FlightStatus Status) FaultCheck = CheckForFault(TIC.PsiAtReading, STABenums.FlightStatus.InFlight);
            TIC.Fault = FaultCheck.Fault;
            TIC.Status = FaultCheck.Status;
            return TIC;
        }

        /// <summary>
        /// The weapon starts out in In flight loiter mode.
        /// if a fault is detected, the weapon switches to Self inert. It can't go to any other state.
        /// It disarms itself and falls to the ground harmlessly
        /// If the weapon detects a target, it switches to terminal mode and attacks without going to
        /// any other state
        /// Flight is terminated when the weapon hits the ground at Altitude 0
        /// </summary>
        /// <param name="telemetryInformation"></param>
        /// <returns></returns>
        public static TelemetryInformationClass GenerateFlightTelemetry(List<TelemetryInformationClass> telemetryInformation)
        {
            TelemetryInformationClass TIC = new TelemetryInformationClass();
            TelemetryInformationClass LastInformationAdded = telemetryInformation[telemetryInformation.Count - 1];

            //Adjust the altitude based on Loiter or Terminal mode
            //if the altitude is 0, terminate the flight
            //we won't have any more data to deploy anyway
            TIC.Altitude = FakeFlightTelemetry.DecrementAltitude(LastInformationAdded.Altitude, LastInformationAdded.Status);
            
            //Remember the engagement time
            TIC.EngagementTime = LastInformationAdded.EngagementTime;

            //Always set the status based on the last status 
            //so that terminal stays terminal and insert stays inert
            TIC.Status = LastInformationAdded.Status;

            if (TIC.Altitude <= 0)
            {
                TIC.Status = STABenums.FlightStatus.Terminated;
                return TIC; // just return. There is no further information to send
            }

            ///If the weapon is loitering, look for a target
            if (LastInformationAdded.Status == STABenums.FlightStatus.InFlight)
            {
                ///Right now we're using the elapsed time to add a measure of randomness
                ///into whether the weapon finds a target.
                TIC.Status = FakeFlightTelemetry.HasFoundTarget(LastInformationAdded.ElapsedFlightTime);
            }

            ///If the weapon is not inert, check the engine pressure
            if (LastInformationAdded.Status != STABenums.FlightStatus.SelfInert)
            {
                TIC = InspectCombustionChamber(telemetryInformation, TIC,LastInformationAdded);
            }

            //regardless of what happens, assemble the general telemetry and update the location
            TIC = AssembleGeneralTelemetry(TIC, LastInformationAdded);

            return TIC;

        }

        /// <summary>
        /// Used for general statistical information like flight time nad location
        /// </summary>
        /// <param name="TIC"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static TelemetryInformationClass AssembleGeneralTelemetry( TelemetryInformationClass TIC, TelemetryInformationClass LastInformationAdded)
            {
                ///Move weapon location
                TIC.Location = FakeFlightTelemetry.GenerateRandomLocationFromLocation(LastInformationAdded.Location);

                //GenerateFlightTime
                TIC.ElapsedFlightTime = LastInformationAdded.ElapsedFlightTime + 1;
                
                if (TIC.Status == STABenums.FlightStatus.Terminal)
                {
                TIC.EngagementTime = TIC.EngagementTime + 1;
                }

                //Generate Timestamp
                TIC.TimeStamp = DateTime.Now;

                return TIC;
            }

        /// <summary>
        /// Inspects the engine combustion chamber for problems calibrates pressure if not at the desired pressure
        /// </summary>
        /// <param name="TIC"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static TelemetryInformationClass InspectCombustionChamber(List<TelemetryInformationClass> telemetryInformation,TelemetryInformationClass TIC, TelemetryInformationClass LastInformationAdded)
        {

            //Check the current pressure of the unit
            TIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();

            //Grab the reccomended pressure.
            TIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;

            //Calibrate the pressure
            (TIC.PsiAfterCalibration, TIC.Action, TIC.Fault, TIC.Status) = CalibratePressure(TIC.PsiAtReading, FakeFlightTelemetry.ReccomendedPressure, TIC.Status);

            //Get the Average Engine Pressure
            TIC.AveragePsi = Convert.ToDecimal(telemetryInformation.Average(item => item.PsiAtReading));

            return TIC;
        }

        ///If the pressure is outside of the standard pressure range, something has gone disasterously
        ///wrong with the engine.  Either the pressure is too low and the engine didn't ignight or
        ///the pressure is too high.  Either way, shut the weapon down, make it inert and let it fall away
        ///from the aircraft do it doesn't blow up in mid-flight.
        ///
        ///If we're already in terminal mode, send back the fault message so we can log it, but
        ///don't let the weapon flip to inert
        private static (STABenums.FaultStatus, STABenums.FlightStatus) CheckForFault(int CurrentPressure, STABenums.FlightStatus Status)
            {


                //If the pressure is out of range, inert the weapon unless terminal
                //else, pass back OK and the current status
                if ((CurrentPressure >= FakeFlightTelemetry.PressureTooHigh) || (CurrentPressure <= FakeFlightTelemetry.PressureTooLow))
                {
                    if (Status == STABenums.FlightStatus.Terminal)
                    {
                        return (STABenums.FaultStatus.Fault, STABenums.FlightStatus.Terminal);
                    }
                    else 
                    {
                      return (STABenums.FaultStatus.Fault, STABenums.FlightStatus.SelfInert);
                    }
                }
                else
                {
                    return (STABenums.FaultStatus.Ok, Status);
                }
  

            }

            /// <summary>
            /// This method raises pressure if it is low, lowers pressure if it is too high and returns 
            /// a fault and changes state if the pressure goes beyond normal limits
            /// </summary>
            /// <param name="OriginalPsi"></param>
            /// <param name="ReccomendedPressure"></param>
            /// <returns></returns>
            private static (int, STABenums.ActionTaken, STABenums.FaultStatus, STABenums.FlightStatus) CalibratePressure(int OriginalPsi, int ReccomendedPressure, STABenums.FlightStatus Status)
            {
                STABenums.ActionTaken Action;

                int CurrentPsi;

                if (OriginalPsi < ReccomendedPressure)
                {
                    Action = STABenums.ActionTaken.AddedPressure;
                    CurrentPsi = FakeFlightTelemetry.IncreasePressure(ReccomendedPressure);

                }
                else if (OriginalPsi > ReccomendedPressure)
                {
                    Action = STABenums.ActionTaken.RemovedPressure;
                    CurrentPsi = FakeFlightTelemetry.DecreasePressure(ReccomendedPressure);
                }
                else
                {
                    Action = STABenums.ActionTaken.NoAction;
                    CurrentPsi = OriginalPsi;
                }

                (STABenums.FaultStatus WeaponFaultStatus, STABenums.FlightStatus WeaponFlightStatus) = CheckForFault(OriginalPsi, Status);

                return (CurrentPsi, Action, WeaponFaultStatus, WeaponFlightStatus);

            }


        }
    }

