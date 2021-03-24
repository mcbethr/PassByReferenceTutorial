using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;
using System.Linq;

namespace OutAndRefTutorial
{
    /// <summary>
    /// This class records weapon telemetry and engine chamber pressure information to
    /// send back to the launching vehicle
    /// </summary>
    public static class EngineTelemetryClass {



        public static ChamberInformationClass GenerateInitialEngineTelemetry()
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            CIC.Altitude = FakeFlightTelemetry.GenerateRandomStartingAltitude();
            CIC.Action = GabEnums.ActionTaken.NoAction; ///Just launched so no action
            CIC.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            CIC.AveragePsi = 0;
            CIC.ElapsedFlightTime = 0;
            CIC.EngagementTime = 0;
            CIC.PsiAfterCalibration = 0;
            CIC.TimeStamp = DateTime.Now;
            CIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;
            CIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();
            (GabEnums.FaultStatus Fault, GabEnums.FlightStatus Status) FaultCheck = CheckForFault(CIC.PsiAtReading, GabEnums.FlightStatus.InFlight);
            CIC.Fault = FaultCheck.Fault;
            CIC.Status = FaultCheck.Status;
            return CIC;
        }

        /// <summary>
        /// The weapon starts out in In flight loiter mode.
        /// if a fault is detected, the weapon switches to Self inert. It can't go to any other state.
        /// It disarms itself and falls to the ground harmlessly
        /// If the weapon detects a target, it switches to terminal mode and attacks without going to
        /// any other state
        /// Flight is terminated when the weapon hits the ground at Altitude 0
        /// </summary>
        /// <param name="chamberInformation"></param>
        /// <returns></returns>
        public static ChamberInformationClass GenerateFlightTelemetry(List<ChamberInformationClass> chamberInformation)
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            ChamberInformationClass LastInformationAdded = chamberInformation[chamberInformation.Count - 1];

            //Adjust the altitude based on Loiter or Terminal mode
            //if the altitude is 0, terminate the flight
            //we won't have any more data to deploy anyway
            CIC.Altitude = FakeFlightTelemetry.DecrementAltitude(LastInformationAdded.Altitude, LastInformationAdded.Status);
            
            //Remember the engagement time
            CIC.EngagementTime = LastInformationAdded.EngagementTime;

            //Always set the status based on the last status 
            //so that terminal stays terminal and insert stays inert
            CIC.Status = LastInformationAdded.Status;

            if (CIC.Altitude <= 0)
            {
                CIC.Status = GabEnums.FlightStatus.Terminated;
                return CIC; // just return. There is no further information to send
            }

            ///If the weapon is loitering, look for a target
            if (LastInformationAdded.Status == GabEnums.FlightStatus.InFlight)
            {
                ///Right now we're using the elapsed time to add a measure of randomness
                ///into whether the weapon finds a target.
                CIC.Status = FakeFlightTelemetry.HasFoundTarget(LastInformationAdded.ElapsedFlightTime);
            }

            ///If the weapon is not inert, check the engine pressure
            if (LastInformationAdded.Status != GabEnums.FlightStatus.SelfInert)
            {
                CIC = InspectCombustionChamber(chamberInformation, CIC,LastInformationAdded);
            }

            //regardless of what happens, assemble the general telemetry and update the location
            CIC = AssembleGeneralTelemetry(CIC, LastInformationAdded);

            return CIC;

        }

        /// <summary>
        /// Used for general statistical information like flight time nad location
        /// </summary>
        /// <param name="CIC"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static ChamberInformationClass AssembleGeneralTelemetry( ChamberInformationClass CIC, ChamberInformationClass LastInformationAdded)
            {
                ///Move weapon location
                CIC.Location = FakeFlightTelemetry.GenerateRandomLocationFromLocation(LastInformationAdded.Location);

                //GenerateFlightTime
                CIC.ElapsedFlightTime = LastInformationAdded.ElapsedFlightTime + 1;
                
                if (CIC.Status == GabEnums.FlightStatus.Terminal)
                {
                CIC.EngagementTime = CIC.EngagementTime + 1;
                }

                //Generate Timestamp
                CIC.TimeStamp = DateTime.Now;

                return CIC;
            }

        /// <summary>
        /// Inspects the engine combustion chamber for problems calibrates pressure if not at the desired pressure
        /// </summary>
        /// <param name="CIC"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static ChamberInformationClass InspectCombustionChamber(List<ChamberInformationClass> ChamberInformation,ChamberInformationClass CIC, ChamberInformationClass LastInformationAdded)
        {

            //Check the current pressure of the unit
            CIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();

            //Grab the reccomended pressure.
            CIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;

            //Calibrate the pressure
            (CIC.PsiAfterCalibration, CIC.Action, CIC.Fault, CIC.Status) = CalibratePressure(CIC.PsiAtReading, FakeFlightTelemetry.ReccomendedPressure, CIC.Status);

            //Get the Average Engine Pressure
            CIC.AveragePsi = Convert.ToDecimal(ChamberInformation.Average(item => item.PsiAtReading));

            return CIC;
        }

        ///If the pressure is outside of the standard pressure range, something has gone disasterously
        ///wrong with the engine.  Either the pressure is too low and the engine didn't ignight or
        ///the pressure is too high.  Either way, shut the weapon down, make it inert and let it fall away
        ///from the aircraft do it doesn't blow up in mid-flight.
        ///
        ///If we're already in terminal mode, send back the fault message so we can log it, but
        ///don't let the weapon flip to inert
        private static (GabEnums.FaultStatus, GabEnums.FlightStatus) CheckForFault(int CurrentPressure, GabEnums.FlightStatus Status)
            {


                //If the pressure is out of range, inert the weapon unless terminal
                //else, pass back OK and the current status
                if ((CurrentPressure >= FakeFlightTelemetry.PressureTooHigh) || (CurrentPressure <= FakeFlightTelemetry.PressureTooLow))
                {
                    if (Status == GabEnums.FlightStatus.Terminal)
                    {
                        return (GabEnums.FaultStatus.Fault, GabEnums.FlightStatus.Terminal);
                    }
                    else 
                    {
                      return (GabEnums.FaultStatus.Fault, GabEnums.FlightStatus.SelfInert);
                    }
                }
                else
                {
                    return (GabEnums.FaultStatus.Ok, Status);
                }
  

            }

            /// <summary>
            /// This method raises pressure if it is low, lowers pressure if it is too high and returns 
            /// a fault and changes state if the pressure goes beyond normal limits
            /// </summary>
            /// <param name="OriginalPsi"></param>
            /// <param name="ReccomendedPressure"></param>
            /// <returns></returns>
            private static (int, GabEnums.ActionTaken, GabEnums.FaultStatus, GabEnums.FlightStatus) CalibratePressure(int OriginalPsi, int ReccomendedPressure, GabEnums.FlightStatus Status)
            {
                GabEnums.ActionTaken Action;

                int CurrentPsi;

                if (OriginalPsi < ReccomendedPressure)
                {
                    Action = GabEnums.ActionTaken.AddedPressure;
                    CurrentPsi = FakeFlightTelemetry.IncreasePressure(ReccomendedPressure);

                }
                else if (OriginalPsi > ReccomendedPressure)
                {
                    Action = GabEnums.ActionTaken.RemovedPressure;
                    CurrentPsi = FakeFlightTelemetry.DecreasePressure(ReccomendedPressure);
                }
                else
                {
                    Action = GabEnums.ActionTaken.NoAction;
                    CurrentPsi = OriginalPsi;
                }

                (GabEnums.FaultStatus WeaponFaultStatus, GabEnums.FlightStatus WeaponFlightStatus) = CheckForFault(OriginalPsi, Status);

                return (CurrentPsi, Action, WeaponFaultStatus, WeaponFlightStatus);

            }


        }
    }

