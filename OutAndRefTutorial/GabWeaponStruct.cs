using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    /// <summary>
    /// Fires a Gab weapon using a pass by reference structure
    /// </summary>
    public class GabWeaponStruct
    {


        ChamberInformationStruct[] _ChamberData = new ChamberInformationStruct[3600];

        public ChamberInformationStruct[] ChamberData { get { return _ChamberData; } }

        public ChamberInformationStruct LastChamberData { get { return _ChamberData[_ChamberData.Length - 1]; } }


        public void ExecuteWeaponFlightTick()
        {
            ChamberInformationStruct CIS = new ChamberInformationStruct();
            
            EngineTelemetryStruct.GenerateFlightTelemetry(ref _ChamberData, ref CIS);
            //_ChamberData.Add(CIS);
            //PrintWeaponTelemetry(CIS);

        }
        /*
        public void DisplayEngagement()
        {
            int AltitudeEngaged = _ChamberData[0].Altitude;
            PrintEngagementStatistics(_ChamberData[_ChamberData.Count - 2], AltitudeEngaged);
        }

        private ChamberInformationClass GenerateInitialTelemetry()
        {

            ChamberInformationClass CIC = EngineTelemetryClass.GenerateInitialEngineTelemetry();
            PrintWeaponTelemetry(CIC);
            return CIC;
        }

        private void PrintWeaponTelemetry(ChamberInformationClass CIC)
        {
            Console.WriteLine("Flt Time: " + CIC.ElapsedFlightTime + " Location: " + CIC.Location.X + "," + CIC.Location.Y + " Engine Pressure: " + CIC.PsiAtReading + " Altitude: " + CIC.Altitude + " Status : " + CIC.Status);
        }

        private void PrintWeaponAway()
        {
            Console.WriteLine("Weapon Away!");
        }

        private void PrintEngagementStatistics(ChamberInformationClass CIC, int AltitudeEngaged)
        {

            Console.WriteLine("*** Engagement report ***");
            Console.WriteLine("Total Flight Time: " + CIC.ElapsedFlightTime + " Engagement Time: " + CIC.EngagementTime + " Final Location: " + CIC.Location.X + "," + CIC.Location.Y + " Avg Engine Pressure: " + Decimal.Round(CIC.AveragePsi, 2) + " Altitude Engaged: " + AltitudeEngaged);
            Console.WriteLine("*** Engagement report ***");
        }
        */
    }
}
