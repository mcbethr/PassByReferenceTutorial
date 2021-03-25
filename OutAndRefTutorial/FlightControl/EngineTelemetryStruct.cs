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
    public static class EngineTelemetryStruct {



        public static ChamberInformationStruct GenerateInitialEngineTelemetry()
        {
            ChamberInformationStruct CIS = new ChamberInformationStruct();
            CIS.Altitude = FakeFlightTelemetry.GenerateRandomStartingAltitude();
            CIS.Action = GabEnums.ActionTaken.NoAction; ///Just launched so no action
            CIS.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            CIS.AveragePsi = 0;
            CIS.ElapsedFlightTime = 0;
            CIS.EngagementTime = 0;
            CIS.PsiAfterCalibration = 0;
            CIS.TimeStamp = DateTime.Now;
            CIS.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;
            CIS.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();
            (GabEnums.FaultStatus Fault, GabEnums.FlightStatus Status) FaultCheck = CheckForFault(CIS.PsiAtReading, GabEnums.FlightStatus.InFlight);
            CIS.Fault = FaultCheck.Fault;
            CIS.Status = FaultCheck.Status;
            return CIS;
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
        public static void GenerateFlightTelemetry(ref ChamberInformationStruct[] chamberInformation, ref ChamberInformationStruct CIS)
        {

            int chamberArrayNextIndex = Array.FindLastIndex(chamberInformation, null);

            ChamberInformationStruct LastInformationAdded = chamberInformation[chamberArrayNextIndex - 1];
           
        //Adjust the altitude based on Loiter or Terminal mode
        //if the altitude is 0, terminate the flight
        //we won't have any more data to deploy anyway
        CIS.Altitude = FakeFlightTelemetry.DecrementAltitude(LastInformationAdded.Altitude, LastInformationAdded.Status);

            //Remember the engagement time
        CIS.EngagementTime = LastInformationAdded.EngagementTime;

        //Always set the status based on the last status 
        //so that terminal stays terminal and insert stays inert
        CIS.Status = LastInformationAdded.Status;

        if (CIS.Altitude <= 0)
        {
            CIS.Status = GabEnums.FlightStatus.Terminated;
        }

        ///If the weapon is loitering, look for a target
        if (LastInformationAdded.Status == GabEnums.FlightStatus.InFlight)
        {
            ///Right now we're using the elapsed time to add a measure of randomness
            ///into whether the weapon finds a target.
            CIS.Status = FakeFlightTelemetry.HasFoundTarget(LastInformationAdded.ElapsedFlightTime);
        }

        ///If the weapon is not inert, check the engine pressure
        if (LastInformationAdded.Status != GabEnums.FlightStatus.SelfInert)
        {
            InspectCombustionChamber(in chamberInformation, ref CIS, in LastInformationAdded);
        }

        //regardless of what happens, assemble the general telemetry and update the location
        AssembleGeneralTelemetry(ref CIS, in LastInformationAdded);

        
        }

        /// <summary>
        /// Used for general statistical information like flight time nad location
        /// </summary>
        /// <param name="CIC"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static void AssembleGeneralTelemetry( ref ChamberInformationStruct CIS, in ChamberInformationStruct LastInformationAdded)
            {
                ///Move weapon location
                CIS.Location = FakeFlightTelemetry.GenerateRandomLocationFromLocation(LastInformationAdded.Location);

                //GenerateFlightTime
                CIS.ElapsedFlightTime = LastInformationAdded.ElapsedFlightTime + 1;
                
                if (CIS.Status == GabEnums.FlightStatus.Terminal)
                {
                CIS.EngagementTime = CIS.EngagementTime + 1;
                }

                //Generate Timestamp
                CIS.TimeStamp = DateTime.Now;
            }

        /// <summary>
        /// Inspects the engine combustion chamber for problems calibrates pressure if not at the desired pressure
        /// </summary>
        /// <param name="CIS"></param>
        /// <param name="LastInformationAdded"></param>
        /// <returns></returns>
            private static void InspectCombustionChamber(in ChamberInformationStruct[] ChamberInformation, ref ChamberInformationStruct CIS, in ChamberInformationStruct LastInformationAdded)
        {

            //Check the current pressure of the unit
            CIS.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();

            //Grab the reccomended pressure.
            CIS.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;

            //Calibrate the pressure
            (CIS.PsiAfterCalibration, CIS.Action, CIS.Fault, CIS.Status) = CalibratePressure(CIS.PsiAtReading, FakeFlightTelemetry.ReccomendedPressure, CIS.Status);

            //Get the Average Engine Pressure
            CIS.AveragePsi = Convert.ToDecimal(ChamberInformation.Average(item => item.PsiAtReading));

            
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

