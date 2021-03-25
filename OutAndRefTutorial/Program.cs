using System;
using System.Diagnostics;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch1.Start();
            GabWeaponClass GWC = new GabWeaponClass();
            
            ///Run as a class
            while (GWC.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTick();
            }
            GWC.DisplayEngagement();
            stopwatch1.Stop();

            stopwatch2.Start();
            //Run as a Structure
            GabWeaponStruct GWS = new GabWeaponStruct();

            while (GWS.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWS.ExecuteWeaponFlightTick();
            }
            GWS.DisplayEngagement();
            stopwatch2.Stop();

            ///display engagement times
            Console.WriteLine("Engagement 1 (Class    ): " + stopwatch1.ElapsedMilliseconds + " milliseconds.");
            Console.WriteLine("Engagement 2 (structure): " + stopwatch2.ElapsedMilliseconds + " milliseconds.");
        }
    }
}
