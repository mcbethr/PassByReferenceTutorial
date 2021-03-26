using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class EngineControl
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


        /// <summary>
        /// Don't ever do this it would be 21600 lines long.
        /// </summary>
        public struct TelemetryInformationStructCrazy
        {
            public int PsiAtReading1;
            public int PsiAfterCalibration1;
            public int ReccomendedPressure1;
            public int Altitude1;
            public decimal AveragePsi1;
            public int ElapsedFlightTime1;
            public int EngagementTime1;
            public STABenums.ActionTaken Action1;
            public STABenums.FaultStatus Fault1;
            public STABenums.FlightStatus Status1;
            public DateTime TimeStamp1;
            public Point Location1;

                    
            public int PsiAtReading2;
            public int PsiAfterCalibration2;
            public int ReccomendedPressure2;
            public int Altitude2;
            public decimal AveragePsi2;
            public int ElapsedFlightTime2;
            public int EngagementTime2;
            public STABenums.ActionTaken Action2;
            public STABenums.FaultStatus Fault2;
            public STABenums.FlightStatus Status2;
            public DateTime TimeStamp2;
            public Point Location2;

            ///And all the way down to...
            ///
            public int PsiAtReading1800;
            public int PsiAfterCalibration1800;
            public int ReccomendedPressure1800;
            public int Altitude1800;
            public decimal AveragePsi1800;
            public int ElapsedFlightTime1800;
            public int EngagementTime1800;
            public STABenums.ActionTaken Action1800;
            public STABenums.FaultStatus Fault1800;
            public STABenums.FlightStatus Status1800;
            public DateTime TimeStamp1800;
            public Point Location1800;
        }



    }
}
