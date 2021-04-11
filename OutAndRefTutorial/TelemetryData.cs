using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class TelemetryData
    {
        public class TelemetryClass
        {
            public long one { get; set; }
            public long two { get; set; }
            public long Average { get; set; }
        }

        public struct TelemetryStruct
        {
            public long one;
            public long two;
            public long Average;
        }





    }
}
