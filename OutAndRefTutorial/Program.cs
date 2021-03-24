using System;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            GabWeaponClass GWC = new GabWeaponClass();
            
            while (GWC.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTurn();
            }
            GWC.DisplayEngagement();

        }
    }
}
