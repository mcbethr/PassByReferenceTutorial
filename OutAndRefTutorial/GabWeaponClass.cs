using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    /// <summary>
    /// Fires the Gab weapon using a class
    /// </summary>
    public class GabWeaponClass
    {
        List<ChamberInformationClass> _ChamberData;
        

        public List<ChamberInformationClass> ChamberData { get { return _ChamberData; } }

        public ChamberInformationClass LastChamberData { get { return _ChamberData[_ChamberData.Count - 1]; } }

        /// <summary>
        /// Fire weapon.  Chaneg flight status to InFlight and get the intital Telemerty
        /// </summary>
        public GabWeaponClass()
        {

            _ChamberData = new List<ChamberInformation.ChamberInformationClass>();
            _ChamberData.Add(GenerateInitialTelemetry());
            
        }

        public void ExecuteWeaponFlightTick()
        {
            ChamberInformationClass CIC = EngineTelemetryClass.GenerateFlightTelemetry(_ChamberData);
            _ChamberData.Add(CIC);
            PrintWeaponTelemetry(CIC);
            
        }

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
            Console.WriteLine("Flt Time: " + CIC.ElapsedFlightTime +" Location: " + CIC.Location.X + "," + CIC.Location.Y + " Engine Pressure: " + CIC.PsiAtReading + " Altitude: " + CIC.Altitude + " Status : " + CIC.Status);
        }

        private void PrintWeaponAway()
        {
            Console.WriteLine("Weapon Away!");
        }

        private void PrintEngagementStatistics(ChamberInformationClass CIC, int AltitudeEngaged)
        {

            Console.WriteLine("*** Engagement report ***");
            Console.WriteLine("Total Flight Time: " + CIC.ElapsedFlightTime + " Engagement Time: " + CIC.EngagementTime + " Final Location: " + CIC.Location.X + "," + CIC.Location.Y + " Avg Engine Pressure: " + Decimal.Round(CIC.AveragePsi,2) + " Altitude Engaged: " + AltitudeEngaged);
            Console.WriteLine("*** Engagement report ***");
        }

    }
}
