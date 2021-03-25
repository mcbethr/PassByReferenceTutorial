using System;
using System.Diagnostics;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            long Engagement1Time = RunClassEngagement();

            long Engagement2Time = RunStructureEngagement();

            Console.WriteLine("Engagement 1 (Class    ): " + Engagement1Time + " milliseconds.");
            Console.WriteLine("Engagement 2 (structure): " + Engagement2Time + " milliseconds.");


        }

        public static long RunClassEngagement()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            GabWeaponClass GWC = new GabWeaponClass();

            ///Run as a class
            while (GWC.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTick();

                ///For debugging
                if (GWC.LastChamberData.Status == GabEnums.FlightStatus.Terminated)
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
            GabWeaponStruct GWS = new GabWeaponStruct();

            while (GWS.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWS.ExecuteWeaponFlightTick();

                ///For debugging
                if (GWS.LastChamberData.Status == GabEnums.FlightStatus.Terminated)
                { //break}
                }
            }
            GWS.DisplayEngagement();
            stopwatch2.Stop();

            return stopwatch2.ElapsedMilliseconds;
        }

    }
}
