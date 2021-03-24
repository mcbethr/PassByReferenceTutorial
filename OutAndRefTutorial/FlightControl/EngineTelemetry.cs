using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    public static class EngineTelemetry { 



        public static ChamberInformationClass GenerateInitialEngineTelemetry()
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            CIC.Altitude = FakeFlightTelemetry.GenerateRandomStartingAltitude();
            CIC.Action = GabEnums.ActionTaken.NoAction; ///Just launched so no action
            CIC.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            CIC.AveragePsi = 0;
            CIC.MedianPsi = 0;
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

        public static ChamberInformationClass GenerateFlightTelemetry(List<ChamberInformationClass> chamberInformation)
        {
            ChamberInformationClass CIC = new ChamberInformationClass();
            var LastInformationAdded = chamberInformation[chamberInformation.Count - 1];

            ///First let's check to see if the weapon has discovered a target 
            CIC.Status = FakeFlightTelemetry.HasFoundTarget(LastInformationAdded.ElapsedFlightTime);

            //Adjust the altitude based on Loiter or Terminal mode
            CIC.Altitude = FakeFlightTelemetry.DecrementAltitude(LastInformationAdded.Altitude, CIC.Status);

            CIC.PsiAtReading = FakeFlightTelemetry.GenerateRandomPressure();

            CIC.PsiAfterCalibration

            //CIC.Action = GabEnums.ActionTaken
            CIC.Location = FakeFlightTelemetry.GenerateRandomStartingLocation();
            CIC.AveragePsi = 0;
            CIC.MedianPsi = 0;
            CIC.ElapsedFlightTime = 0;
            CIC.ElapsedFlightTimeToTargetIdentification = 0;
            CIC.TimeOfReading = DateTime.Now;
            CIC.ReccomendedPressure = FakeFlightTelemetry.ReccomendedPressure;
            
            (GabEnums.FaultStatus Fault, GabEnums.FlightStatus Status) FaultCheck = CheckForFault(CIC.PsiAtReading);
            CIC.Fault = FaultCheck.Fault;
            CIC.Status = FaultCheck.Status;
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

        private (int CalibratePeessure(int Psi, int ReccomendedPressure)
        {

        }
 

    }
}
