using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class ChamberInformation
    {

        public struct TelemetryInformationStruct
        {
            public int PsiAtReading;
            public int PsiAfterCalibration;
            public int ReccomendedPressure;
            public int Altitude;
            public decimal AveragePsi;
            public int ElapsedFlightTime;
            public int EngagementTime;
            public STABenums.ActionTaken Action;
            public STABenums.FaultStatus Fault;
            public STABenums.FlightStatus Status;
            public DateTime TimeStamp;
            public Point Location;
        }

        public class TelemetryInformationClass
        {
            public int PsiAtReading { get; set; }
            public int Altitude { get; set; }
            public int PsiAfterCalibration { get; set; }
            public decimal AveragePsi { get; set; }
            public int ElapsedFlightTime { get; set; }
            public int EngagementTime { get; set; }
            public int ReccomendedPressure { get; set; }
            public STABenums.ActionTaken Action { get; set; }
            public STABenums.FaultStatus Fault { get; set; }
            public STABenums.FlightStatus Status{ get; set; }
            public DateTime TimeStamp { get; set; }
            public Point Location { get; set; }
        }

    }
}
