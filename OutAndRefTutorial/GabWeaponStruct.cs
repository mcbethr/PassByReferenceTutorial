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
        private int _CurrentTick = 0;

        ChamberInformationStruct[] _ChamberData = new ChamberInformationStruct[3600];

        public ChamberInformationStruct[] ChamberData { get { return _ChamberData; } }

        public ChamberInformationStruct LastChamberData { get { return _ChamberData[_CurrentTick-1]; } }

        public GabWeaponStruct()
        {
            ChamberInformationStruct CIS = new ChamberInformationStruct();
            GenerateInitialTelemetry(out CIS);
            _ChamberData[0] = CIS;
            _CurrentTick++;
        }

        public void ExecuteWeaponFlightTick()
        {
            ChamberInformationStruct CIS = new ChamberInformationStruct();
            
            EngineTelemetryStruct.GenerateFlightTelemetry(ref _ChamberData, ref CIS, in _CurrentTick);

            
            _ChamberData[_CurrentTick] = CIS;
            PrintWeaponTelemetry(ref CIS);
            _CurrentTick++;

        }
        
        public void DisplayEngagement()
        {
            int AltitudeEngaged = _ChamberData[0].Altitude;
            
            PrintEngagementStatistics(ref _ChamberData[(_CurrentTick - 2)], AltitudeEngaged);
        }

        private void GenerateInitialTelemetry(out ChamberInformationStruct CIS)
        {
            
            EngineTelemetryStruct.GenerateInitialEngineTelemetry(out CIS);
            PrintWeaponTelemetry(ref CIS);
            
        }

        private void PrintWeaponTelemetry(ref ChamberInformationStruct CIS)
        {
            Console.WriteLine("Flt Time: " + CIS.ElapsedFlightTime + " Location: " + CIS.Location.X + "," + CIS.Location.Y + " Engine Pressure: " + CIS.PsiAtReading + " Altitude: " + CIS.Altitude + " Status : " + CIS.Status);
        }

        private void PrintWeaponAway()
        {
            Console.WriteLine("Weapon Away!");
        }

        private void PrintEngagementStatistics(ref ChamberInformationStruct CIS, int AltitudeEngaged)
        {

            Console.WriteLine("*** Engagement report ***");
            Console.WriteLine("Total Flight Time: " + CIS.ElapsedFlightTime + " Engagement Time: " + CIS.EngagementTime + " Final Location: " + CIS.Location.X + "," + CIS.Location.Y + " Avg Engine Pressure: " + Decimal.Round(CIS.AveragePsi, 2) + " Altitude Engaged: " + AltitudeEngaged);
            Console.WriteLine("*** Engagement report ***");
        }
        
    }
}
