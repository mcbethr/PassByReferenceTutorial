using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OutAndRefTutorial
{
    public class AdvancedExample
    {
        public struct ChamberInformationStruct{
            int PsiAtReading;
            int PsiAfterCalibration;
            int ReccomendedPressure;
            int Altitude;
            AircraftEnums.ActionTaken Action;
            AircraftEnums.FaultStatus Fault;
            DateTime TimeOfReading;
            Point Location;
        }

        public class ChamberInformationClass
        {
            public int PsiAtReading { get; set; }
            public int Altitude { get; set; }
            public int PsiAfterCalibration { get; set; }
            public int ReccomendedPressure { get; set; }
            public AircraftEnums.ActionTaken Action {get;set;}
            public AircraftEnums.FaultStatus Fault { get; set; }
            public DateTime TimeOfReading { get; set; }
            public Point Location { get; set; }
        }

        public AdvancedExample()
        {

        }

        public (Point,int,int) GenerateInitialFakeFlightData()
        {

        }

        /// <summary>
        /// This creates fake flight data to populate ChamberInformation
        /// </summary>
        public (Point, int, int) GenerateFakeFlightData(Point Location, int Psi, int Altitude)
        {
            Location = GenerateRandomLocationFromLocation(Location);
            Psi = GenerateRandomPressure();
            Altitude = DecrementAltitude(Altitude);

            return (Location, Psi, Altitude);
        }

        public Point GenerateRandomStartingLocation()
        {
            Random rnd = new Random();
            return (new Point(rnd.Next(0, 10), rnd.Next(0,10)));
        }

        /// <summary>
        /// Weapon can glide 1 up to unit per second from its previous location
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        public Point GenerateRandomLocationFromLocation(Point Location)
        {
            Random rnd = new Random();
            int NorthSouth = rnd.Next(-1, 1);
            int EastWest = rnd.Next(-1, 1);

            return (new Point((Location.Y + NorthSouth), (Location.X - EastWest)));
        }

        /// <summary>
        /// Generates a random pressure.  Should always be between 40 and 70.
        /// If less than 39 or greater than 71, this will indicate a fault
        /// </summary>
        /// <returns></returns>
        public int GenerateRandomPressure()
        {
            Random rnd = new Random();
            return (rnd.Next(39, 71));
        }

        /// <summary>
        /// Starting altitude can be anywhere between 1000 FT and 36000 Ft.
        /// The weapon drops 10 feet for every second of flight when in glide mode
        /// </summary>
        /// <returns></returns>
        public int GenerateRandomStartingAltitude()
        {
            Random rnd = new Random();
            return (rnd.Next(1000, 36000));
        }

        /// <summary>
        /// Decrements a specific altitude if the weapon has found a target and is diving
        /// Altitude cannot be below 0;
        /// </summary>
        /// <param name="Altitude"></param>
        /// <returns></returns>
        public int DecrementAltitude(int CurrentAltitude, int AltitudeToDecrement)
        {
            int Altitude = CurrentAltitude - AltitudeToDecrement;
            if (Altitude<0)
            {
                ///Flight it terminated
                Altitude = 0;
            }

            return Altitude;
        }

        public int DecrementAltitude(int CurrentAltitude)
        {
            int Altitude = CurrentAltitude - 20;
            if (Altitude < 0)
            {
                ///Flight it terminated
                Altitude = 0;
            }

            return Altitude;
        }

    }
}
