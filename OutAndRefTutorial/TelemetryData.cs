using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class TelemetryData
    {

        public struct TelemetryInformationStruct
        {
            public long Sensor1;
            public long Sensor2;
            public long Sensor3;
        }

        public class TelemetryInformationClass
        {
            public long Sensor1 { get; set; }
            public long Sensor2 { get; set; }
            public long Sensor3 { get; set; }
        }





    }
}
