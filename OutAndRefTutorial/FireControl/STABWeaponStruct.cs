using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.EngineControl;

namespace OutAndRefTutorial
{
    /// <summary>
    /// Fires the STAB weapon using a Struct
    /// STAB - Standoff Telemetry Assisted Bomb
    /// </summary>
    public class STABWeaponStruct
    {
        private int _CurrentTick = 0;

        TelemetryInformationStruct[] _TelemetryData = new TelemetryInformationStruct[FakeFlightTelemetry.GlideBombTotalTicks];

        public TelemetryInformationStruct[] TelemetryData { get { return _TelemetryData; } }

        public TelemetryInformationStruct LastTelemetryData { get { return _TelemetryData[_CurrentTick-1]; } }

        public STABWeaponStruct()
        {
            TelemetryInformationStruct TIS = new TelemetryInformationStruct();
            GenerateInitialTelemetry(out TIS);
            _TelemetryData[0] = TIS;
            _CurrentTick++;
        }

        public void ExecuteWeaponFlightTick()
        {
            TelemetryInformationStruct TIS = new TelemetryInformationStruct();
            
            EngineTelemetryStruct.GenerateFlightTelemetry(ref _TelemetryData, ref TIS, in _CurrentTick);

            
            _TelemetryData[_CurrentTick] = TIS;
            PrintWeaponTelemetry(ref TIS);
            _CurrentTick++;

        }
        
        public void DisplayEngagement()
        {
            int AltitudeEngaged = _TelemetryData[0].Altitude;
            
            PrintEngagementStatistics(ref _TelemetryData[(_CurrentTick - 2)], AltitudeEngaged);
        }

        private void GenerateInitialTelemetry(out TelemetryInformationStruct TIS)
        {
            
            EngineTelemetryStruct.GenerateInitialEngineTelemetry(out TIS);
            PrintWeaponAway();
            PrintWeaponTelemetry(ref TIS);
  


        }

        private void PrintWeaponTelemetry(ref TelemetryInformationStruct TIS)
        {
            Console.WriteLine("Flt Time: " + TIS.ElapsedFlightTime + " Location: " + TIS.Location.X + "," + TIS.Location.Y + " Engine Pressure: " + TIS.PsiAtReading + " Altitude: " + TIS.Altitude + " Status : " + TIS.Status);
        }

        private void PrintWeaponAway()
        {
            Console.WriteLine("Structure - Standoff Telemetry Assisted Bomb Away!");
        }

        private void PrintEngagementStatistics(ref TelemetryInformationStruct TIS, int AltitudeEngaged)
        {

            Console.WriteLine("*** STAB Engagement report ***");
            Console.WriteLine("Total Flight Time: " + TIS.ElapsedFlightTime + " Engagement Time: " + TIS.EngagementTime + " Final Location: " + TIS.Location.X + "," + TIS.Location.Y + " Avg Engine Pressure: " + Decimal.Round(TIS.AveragePsi, 2) + " Altitude Engaged: " + AltitudeEngaged);
            Console.WriteLine("*** STAB Engagement report ***");
        }
        
    }
}
