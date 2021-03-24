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
    public static class EngineTelemetry { 



        public static ChamberInformationClass GenerateInitialEngineTelemetry()
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            CIC.Altitude = FakeFlightTelemetry.GenerateRandomStartingAltitude();
            CIC.Action = GabEnums.ActionTaken.NoAction; ///Just launched so no action
            CIC.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            CIC.AveragePsi = 0;
            CIC.ElapsedFlightTime = 0;
            CIC.ElapsedFlightTimeToTargetIdentification = 0;
            CIC.PsiAfterCalibration = 0;
            CIC.TimeOfReading = DateTime.Now;
            CIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;
            CIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();
            (GabEnums.FaultStatus Fault, GabEnums.FlightStatus Status) FaultCheck = CheckForFault(CIC.PsiAtReading);
            CIC.Fault = FaultCheck.Fault;
            CIC.Status = FaultCheck.Status;
            return CIC;
        }

        /// <summary>
        /// If the weapon has found a target, then change status modes and begin the attack.
        /// If it hasn't, continue to loiter.
        /// Regardless of attack mode or loiter mode, 
        /// </summary>
        /// <param name="chamberInformation"></param>
        /// <returns></returns>
        public static ChamberInformationClass GenerateFlightTelemetry(List<ChamberInformationClass> chamberInformation)
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            var LastInformationAdded = chamberInformation[chamberInformation.Count - 1];

            ///First let's check to see if the weapon has discovered a target 
            CIC.Status = FakeFlightTelemetry.HasFoundTarget(LastInformationAdded.ElapsedFlightTime);

            //Adjust the altitude based on Loiter or Terminal mode
            CIC.Altitude = FakeFlightTelemetry.DecrementAltitude(LastInformationAdded.Altitude, CIC.Status);

            //Check the current pressure of the unit
            CIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();

            CIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;

            //Calibrate the pressure
            (CIC.PsiAfterCalibration, CIC.Action, CIC.Fault, CIC.Status) = CalibratePressure(CIC.PsiAtReading, FakeFlightTelemetry.ReccomendedPressure);

            //Move the weapon location
            CIC.Location = FakeFlightTelemetry.GenerateRandomLocationFromLocation(LastInformationAdded.Location);

            CIC.AveragePsi = chamberInformation.Sum(item => item.PsiAfterCalibration);

            CIC.ElapsedFlightTime = LastInformationAdded.ElapsedFlightTime+1;
            if (CIC.Status != GabEnums.FlightStatus.Terminal)
            {
                CIC.ElapsedFlightTimeToTargetIdentification = CIC.ElapsedFlightTime;
            }

            CIC.TimeOfReading = DateTime.Now;

            
            return CIC;
        }

        private static (GabEnums.FaultStatus, GabEnums.FlightStatus) CheckForFault(int Psi)
        {
            ///If the pressure is outside of the standard pressures, something has gone disasterously
            ///wrong with the engine.  Either the pressure is too low and the engine didn't ignight or
            ///the pressure is too high.  Either way, shut the bomb down, make it inert and let it fall awa
            ///from the aircraft do it doesn't blow up in bid-flight
            if ((Psi <= FakeFlightTelemetry.PressureTooLow) || (Psi >= FakeFlightTelemetry.PressureTooHigh ))
            {

                return (GabEnums.FaultStatus.Fault,GabEnums.FlightStatus.SelfInert);
            }
            else
            {
                return (GabEnums.FaultStatus.Ok,GabEnums.FlightStatus.InFlight);
            }
        }

        /// <summary>
        /// This method raises pressure if it is low, lowers pressure if it is too high and returns 
        /// a fault and changes state if the pressure goes beyond normal limits
        /// </summary>
        /// <param name="OriginalPsi"></param>
        /// <param name="ReccomendedPressure"></param>
        /// <returns></returns>
        private static (int,GabEnums.ActionTaken,GabEnums.FaultStatus, GabEnums.FlightStatus) CalibratePressure(int OriginalPsi, int ReccomendedPressure)
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

            (GabEnums.FaultStatus WeaponFaultStatus,GabEnums.FlightStatus WeaponFlightStatus) = CheckForFault(CurrentPsi);

            return (CurrentPsi, Action, WeaponFaultStatus, WeaponFlightStatus);

        }
 

    }
}
