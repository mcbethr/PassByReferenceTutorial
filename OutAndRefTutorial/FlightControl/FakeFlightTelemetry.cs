﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OutAndRefTutorial
{
    public static class FakeFlightTelemetry
    {
        /// <summary>
        /// Engine Cumbustion chamber pressure should always be 55 for now;
        /// </summary>
        public static int ReccomendedPressure = 55;
        public static int PressureTooLow = 39;
        public static int PressureTooHigh = 71;
        public static int MinimumReleaseAltitude = 1000;
        public static int MaximumReleaseAltitude = 36000;
        public static int AltitudePerSecondLost = 20;
        public static int TerminalAltitudePerSecondLost = 220;
        public static int FindTargetPercentageChance = 50;
        public static int PressureAdjustmentSuccessChance = 100;

        public static (Point,int,int) GenerateInitialFakeFlightData()
        {
            (Point Location, int Psi, int Altitude) WeaponRelease;

            WeaponRelease.Location = GenerateRandomStartingLocation();
            WeaponRelease.Psi = GenerateRandomPressure();
            WeaponRelease.Altitude = GenerateRandomStartingAltitude();

            return WeaponRelease;
        }

        public static Point GenerateRandomStartingLocation()
        {
            Random rnd = new Random();
            return (new Point(rnd.Next(0, 10), rnd.Next(0,10)));
        }

        /// <summary>
        /// Weapon can glide 1 up to unit per second from its previous location
        /// </summary>
        /// <param name="Location"></param>
        /// <returns></returns>
        public static Point GenerateRandomLocationFromLocation(Point Location)
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
        public static int GenerateRandomPressure()
        {
            Random rnd = new Random();
            return (rnd.Next(PressureTooLow, PressureTooHigh));
        }

        public static int AttemptToAdjustPressure(int TargetPressure, int OriginalPressure)
        {
            Random rnd = new Random();

            int SuccessChance = rnd.Next(PressureAdjustmentSuccessChance, 100);

        }

        /// <summary>
        /// Starting altitude can be anywhere between 1000 FT and 36000 Ft.
        /// The weapon drops 10 feet for every second of flight when in glide mode
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomStartingAltitude()
        {
            Random rnd = new Random();
            return (rnd.Next(MinimumReleaseAltitude, MaximumReleaseAltitude));
        }

        /// <summary>
        /// Decrements a specific altitude if the weapon has found a target and is diving
        /// Altitude cannot be below 0;
        /// </summary>
        /// <param name="Altitude"></param>
        /// <returns></returns>
        public static int DecrementAltitude(int CurrentAltitude, int AltitudeToDecrement)
        {
            int Altitude = CurrentAltitude - AltitudeToDecrement;
            if (Altitude<0)
            {
                ///Flight it terminated
                Altitude = 0;
            }

            return Altitude;
        }

        /// <summary>
        /// Automatically decrements altitude based on Loiter or Terminal Mode
        /// </summary>
        /// <param name="CurrentAltitude"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static int DecrementAltitude(int CurrentAltitude, GabEnums.FlightStatus Status)
        {
            if ((Status == GabEnums.FlightStatus.InFlight) || (Status == GabEnums.FlightStatus.SelfInert))
            {
                return DecrementLoiterAltitude(CurrentAltitude);
            }
            else
            {
                return DecrementTerminalAltitude(CurrentAltitude);
            }

        }

        private static int DecrementLoiterAltitude(int CurrentAltitude)
        {
            int Altitude = CurrentAltitude - AltitudePerSecondLost;
            if (Altitude <= 0)
            {
                ///Flight it terminated
                Altitude = 0;
            }

            return Altitude;
        }

        private static int DecrementTerminalAltitude(int CurrentAltitude)
        {
            int Altitude = CurrentAltitude - TerminalAltitudePerSecondLost;
            if (Altitude <= 0)
            {
                ///Flight terminated
                Altitude = 0;
            }

            return Altitude;
        }

        public static GabEnums.FlightStatus HasFoundTarget(int secondsAloft)
        {
            Random rnd = new Random();
            int FoundTarget = rnd.Next(secondsAloft + FindTargetPercentageChance, 100);

            if (FoundTarget >= 100)
            {
                return GabEnums.FlightStatus.Terminal;
            }
            else
            {
                return GabEnums.FlightStatus.InFlight;
            }
        }

    }
}