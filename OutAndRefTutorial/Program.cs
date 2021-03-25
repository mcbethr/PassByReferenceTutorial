using System;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            GabWeaponClass GWC = new GabWeaponClass();
            
            ///Run as a class
            while (GWC.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTurn();
            }
            GWC.DisplayEngagement();

            //Run as a Structure
            GabWeaponStruct GWS = new GabWeaponStruct();
            while(GWS.LastChamberData.Status != GabEnums.FlightStatus.Terminated)
            {
                GWC.ExecuteWeaponFlightTurn();
            }
            GWS.
        }
    }
}
