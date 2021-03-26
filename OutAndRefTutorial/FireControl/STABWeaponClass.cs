using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    /// <summary>
    /// Fires the STAB weapon using a class
    /// STAB - Standoff Telemetry Assisted Bomb
    /// </summary>
    public class STABWeaponClass
    {
        List<TelemetryInformationClass> _TelemetryData;
        

        public List<TelemetryInformationClass> TelemetryData { get { return _TelemetryData; } }

        public TelemetryInformationClass LastTelemetryData { get { return _TelemetryData[_TelemetryData.Count - 1]; } }

        /// <summary>
        /// Fire weapon in the Constructor.  Change flight status to InFlight and get the intital Telemerty
        /// </summary>
        public STABWeaponClass()
        {

            _TelemetryData = new List<ChamberInformation.TelemetryInformationClass>();
            PrintWeaponAway();
            _TelemetryData.Add(GenerateInitialTelemetry());



        }

        public void ExecuteWeaponFlightTick()
        {
            TelemetryInformationClass TIC = EngineTelemetryClass.GenerateFlightTelemetry(_TelemetryData);
            _TelemetryData.Add(TIC);
            PrintWeaponTelemetry(TIC);
            
        }

        public void DisplayEngagement()
        {
            int AltitudeEngaged = _TelemetryData[0].Altitude;
            PrintEngagementStatistics(_TelemetryData[_TelemetryData.Count - 2], AltitudeEngaged);
        }

        private TelemetryInformationClass GenerateInitialTelemetry()
        { 

            TelemetryInformationClass TIC = EngineTelemetryClass.GenerateInitialEngineTelemetry();
            PrintWeaponTelemetry(TIC);
            return TIC;
        }

        private void PrintWeaponTelemetry(TelemetryInformationClass TIC)
        {
            Console.WriteLine("Flt Time: " + TIC.ElapsedFlightTime +" Location: " + TIC.Location.X + "," + TIC.Location.Y + " Engine Pressure: " + TIC.PsiAtReading + " Altitude: " + TIC.Altitude + " Status : " + TIC.Status);
        }

        private void PrintWeaponAway()
        {
            Console.WriteLine("Class - Standoff Telemetry Assisted Bomb Away!");
        }

        private void PrintEngagementStatistics(TelemetryInformationClass TIC, int AltitudeEngaged)
        {

            Console.WriteLine("*** STAB Engagement report ***");
            Console.WriteLine("Total Flight Time: " + TIC.ElapsedFlightTime + " Engagement Time: " + TIC.EngagementTime + " Final Location: " + TIC.Location.X + "," + TIC.Location.Y + " Avg Engine Pressure: " + Decimal.Round(TIC.AveragePsi,2) + " Altitude Engaged: " + AltitudeEngaged);
            Console.WriteLine("*** STAB Engagement report ***");
        }

    }
}
