using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class ChamberInformation
    {

        public struct ChamberInformationStruct
        {
            public int PsiAtReading;
            public int PsiAfterCalibration;
            public int ReccomendedPressure;
            public int Altitude;
            public decimal AveragePsi;
            public int ElapsedFlightTime;
            public int EngagementTime;
            public GabEnums.ActionTaken Action;
            public GabEnums.FaultStatus Fault;
            public GabEnums.FlightStatus Status;
            public DateTime TimeStamp;
            public Point Location;
        }

        public class ChamberInformationClass
        {
            public int PsiAtReading { get; set; }
            public int Altitude { get; set; }
            public int PsiAfterCalibration { get; set; }
            public decimal AveragePsi { get; set; }
            public int ElapsedFlightTime { get; set; }
            public int EngagementTime { get; set; }
            public int ReccomendedPressure { get; set; }
            public GabEnums.ActionTaken Action { get; set; }
            public GabEnums.FaultStatus Fault { get; set; }
            public GabEnums.FlightStatus Status{ get; set; }
            public DateTime TimeStamp { get; set; }
            public Point Location { get; set; }
        }

    }
}
