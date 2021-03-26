using System;
using System.Diagnostics;
using static OutAndRefTutorial.EngineControl;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //long Engagement1Time = RunClassEngagement();

            long Engagement2Time = RunStructureEngagement();

            //Console.WriteLine("Engagement 1 (Class    ): " + Engagement1Time + " milliseconds.");
            //Console.WriteLine("Engagement 2 (structure): " + Engagement2Time + " milliseconds.");


        }

        public static long RunClassEngagement()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            STABWeaponClass GWC = new STABWeaponClass();

            ///Run as a class
            while (GWC.LastTelemetryData.Status != STABenums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTick();
                //Here is where we would Transmit telemetry to aircraft.

                ///For debugging
                if (GWC.LastTelemetryData.Status == STABenums.FlightStatus.Terminated)
                { //break
                }
            }
            GWC.DisplayEngagement();
            stopwatch1.Stop();
            return stopwatch1.ElapsedMilliseconds;
        }










        public static long RunStructureEngagement()
        {
            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch2.Start();
            //Run as a Structure

            STABWeaponStruct GWS = new STABWeaponStruct();

            while (GWS.LastTelemetryData.Status != STABenums.FlightStatus.Terminated)
            {
                GWS.ExecuteWeaponFlightTick();
                //Here is where we would Transmit telemetry to aircraft.


                ///For debugging
                if (GWS.LastTelemetryData.Status == STABenums.FlightStatus.Terminated)
                { //break}
                }
            }
            GWS.DisplayEngagement();
            stopwatch2.Stop();

            return stopwatch2.ElapsedMilliseconds;
        }

    }
}
