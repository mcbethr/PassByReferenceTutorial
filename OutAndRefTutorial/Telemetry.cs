using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static OutAndRefTutorial.TelemetryData;

namespace OutAndRefTutorial
{
    public class Telemetry
    {


        public TelemetryInformationClass FillTelemetry(TelemetryInformationClass TIC)
        {

            TIC.Sensor1 = GenerateTelemetry();
            TIC.Sensor2 = GenerateTelemetry();
            TIC.Sensor3 = GenerateTelemetry();
            TIC.Sensor4 = GenerateTelemetry();
            TIC.Sensor5 = GenerateTelemetry();
            TIC.Sensor6 = GenerateTelemetry();
            TIC.Sensor7 = GenerateTelemetry();
            TIC.Sensor8 = GenerateTelemetry();
            TIC.Sensor9 = GenerateTelemetry();
            TIC.Sensor10 = GenerateTelemetry();
            TIC.Sensor11 = GenerateTelemetry();
            TIC.Sensor12 = GenerateTelemetry();
            TIC.Sensor13 = GenerateTelemetry();
            TIC.Sensor14 = GenerateTelemetry();
            TIC.Sensor15 = GenerateTelemetry();
            TIC.Sensor16 = GenerateTelemetry();
            TIC.Sensor17 = GenerateTelemetry();
            TIC.Sensor18 = GenerateTelemetry();
            TIC.Sensor19 = GenerateTelemetry();
            TIC.Sensor20 = GenerateTelemetry();
            TIC.Sensor21 = GenerateTelemetry();
            TIC.Sensor22 = GenerateTelemetry();
            TIC.Sensor23 = GenerateTelemetry();
            TIC.Sensor24 = GenerateTelemetry();
            TIC.Sensor25 = GenerateTelemetry();
            TIC.Sensor26 = GenerateTelemetry();
            TIC.Sensor27 = GenerateTelemetry();
            TIC.Sensor28 = GenerateTelemetry();
            TIC.Sensor29 = GenerateTelemetry();
            TIC.Sensor30 = GenerateTelemetry();
            TIC.Sensor31 = GenerateTelemetry();
            TIC.Sensor32 = GenerateTelemetry();
            TIC.Sensor33 = GenerateTelemetry();
            TIC.Sensor34 = GenerateTelemetry();
            TIC.Sensor35 = GenerateTelemetry();
            TIC.Sensor36 = GenerateTelemetry();
            TIC.Sensor37 = GenerateTelemetry();
            TIC.Sensor38 = GenerateTelemetry();
            TIC.Sensor39 = GenerateTelemetry();
            TIC.Sensor40 = GenerateTelemetry();
            TIC.Sensor41 = GenerateTelemetry();
            TIC.Sensor42 = GenerateTelemetry();
            TIC.Sensor43 = GenerateTelemetry();
            TIC.Sensor44 = GenerateTelemetry();
            TIC.Sensor45 = GenerateTelemetry();
            TIC.Sensor46 = GenerateTelemetry();
            TIC.Sensor47 = GenerateTelemetry();
            TIC.Sensor48 = GenerateTelemetry();
            TIC.Sensor49 = GenerateTelemetry();
            TIC.Sensor50 = GenerateTelemetry();
            TIC.Sensor51 = GenerateTelemetry();
            TIC.Sensor52 = GenerateTelemetry();
            TIC.Sensor53 = GenerateTelemetry();
            TIC.Sensor54 = GenerateTelemetry();
            TIC.Sensor55 = GenerateTelemetry();
            TIC.Sensor56 = GenerateTelemetry();
            TIC.Sensor57 = GenerateTelemetry();
            TIC.Sensor58 = GenerateTelemetry();
            TIC.Sensor59 = GenerateTelemetry();
            TIC.Sensor60 = GenerateTelemetry();
            TIC.Sensor61 = GenerateTelemetry();
            TIC.Sensor62 = GenerateTelemetry();
            TIC.Sensor63 = GenerateTelemetry();
            TIC.Sensor64 = GenerateTelemetry();
            TIC.Sensor65 = GenerateTelemetry();
            TIC.Sensor66 = GenerateTelemetry();
            TIC.Sensor67 = GenerateTelemetry();
            TIC.Sensor68 = GenerateTelemetry();
            TIC.Sensor69 = GenerateTelemetry();
            TIC.Sensor70 = GenerateTelemetry();
            TIC.Sensor71 = GenerateTelemetry();
            TIC.Sensor72 = GenerateTelemetry();
            TIC.Sensor73 = GenerateTelemetry();
            TIC.Sensor74 = GenerateTelemetry();
            TIC.Sensor75 = GenerateTelemetry();
            TIC.Sensor76 = GenerateTelemetry();
            TIC.Sensor77 = GenerateTelemetry();
            TIC.Sensor78 = GenerateTelemetry();
            TIC.Sensor79 = GenerateTelemetry();
            TIC.Sensor80 = GenerateTelemetry();
            TIC.Sensor81 = GenerateTelemetry();
            TIC.Sensor82 = GenerateTelemetry();
            TIC.Sensor83 = GenerateTelemetry();
            TIC.Sensor84 = GenerateTelemetry();
            TIC.Sensor85 = GenerateTelemetry();
            TIC.Sensor86 = GenerateTelemetry();
            TIC.Sensor87 = GenerateTelemetry();
            TIC.Sensor88 = GenerateTelemetry();
            TIC.Sensor89 = GenerateTelemetry();
            TIC.Sensor90 = GenerateTelemetry();
            TIC.Sensor91 = GenerateTelemetry();
            TIC.Sensor92 = GenerateTelemetry();
            TIC.Sensor93 = GenerateTelemetry();
            TIC.Sensor94 = GenerateTelemetry();
            TIC.Sensor95 = GenerateTelemetry();
            TIC.Sensor96 = GenerateTelemetry();
            TIC.Sensor97 = GenerateTelemetry();
            TIC.Sensor98 = GenerateTelemetry();
            TIC.Sensor99 = GenerateTelemetry();
            TIC.Sensor100 = GenerateTelemetry();

            return TIC;
        }

        public void FillTelemetry(ref TelemetryInformationStruct TIS)
        {

            TIS.Sensor1 = GenerateTelemetry();
            TIS.Sensor2 = GenerateTelemetry();
            TIS.Sensor3 = GenerateTelemetry();
            TIS.Sensor4 = GenerateTelemetry();
            TIS.Sensor5 = GenerateTelemetry();
            TIS.Sensor6 = GenerateTelemetry();
            TIS.Sensor7 = GenerateTelemetry();
            TIS.Sensor8 = GenerateTelemetry();
            TIS.Sensor9 = GenerateTelemetry();
            TIS.Sensor10 = GenerateTelemetry();
            TIS.Sensor11 = GenerateTelemetry();
            TIS.Sensor12 = GenerateTelemetry();
            TIS.Sensor13 = GenerateTelemetry();
            TIS.Sensor14 = GenerateTelemetry();
            TIS.Sensor15 = GenerateTelemetry();
            TIS.Sensor16 = GenerateTelemetry();
            TIS.Sensor17 = GenerateTelemetry();
            TIS.Sensor18 = GenerateTelemetry();
            TIS.Sensor19 = GenerateTelemetry();
            TIS.Sensor20 = GenerateTelemetry();
            TIS.Sensor21 = GenerateTelemetry();
            TIS.Sensor22 = GenerateTelemetry();
            TIS.Sensor23 = GenerateTelemetry();
            TIS.Sensor24 = GenerateTelemetry();
            TIS.Sensor25 = GenerateTelemetry();
            TIS.Sensor26 = GenerateTelemetry();
            TIS.Sensor27 = GenerateTelemetry();
            TIS.Sensor28 = GenerateTelemetry();
            TIS.Sensor29 = GenerateTelemetry();
            TIS.Sensor30 = GenerateTelemetry();
            TIS.Sensor31 = GenerateTelemetry();
            TIS.Sensor32 = GenerateTelemetry();
            TIS.Sensor33 = GenerateTelemetry();
            TIS.Sensor34 = GenerateTelemetry();
            TIS.Sensor35 = GenerateTelemetry();
            TIS.Sensor36 = GenerateTelemetry();
            TIS.Sensor37 = GenerateTelemetry();
            TIS.Sensor38 = GenerateTelemetry();
            TIS.Sensor39 = GenerateTelemetry();
            TIS.Sensor40 = GenerateTelemetry();
            TIS.Sensor41 = GenerateTelemetry();
            TIS.Sensor42 = GenerateTelemetry();
            TIS.Sensor43 = GenerateTelemetry();
            TIS.Sensor44 = GenerateTelemetry();
            TIS.Sensor45 = GenerateTelemetry();
            TIS.Sensor46 = GenerateTelemetry();
            TIS.Sensor47 = GenerateTelemetry();
            TIS.Sensor48 = GenerateTelemetry();
            TIS.Sensor49 = GenerateTelemetry();
            TIS.Sensor50 = GenerateTelemetry();
            TIS.Sensor51 = GenerateTelemetry();
            TIS.Sensor52 = GenerateTelemetry();
            TIS.Sensor53 = GenerateTelemetry();
            TIS.Sensor54 = GenerateTelemetry();
            TIS.Sensor55 = GenerateTelemetry();
            TIS.Sensor56 = GenerateTelemetry();
            TIS.Sensor57 = GenerateTelemetry();
            TIS.Sensor58 = GenerateTelemetry();
            TIS.Sensor59 = GenerateTelemetry();
            TIS.Sensor60 = GenerateTelemetry();
            TIS.Sensor61 = GenerateTelemetry();
            TIS.Sensor62 = GenerateTelemetry();
            TIS.Sensor63 = GenerateTelemetry();
            TIS.Sensor64 = GenerateTelemetry();
            TIS.Sensor65 = GenerateTelemetry();
            TIS.Sensor66 = GenerateTelemetry();
            TIS.Sensor67 = GenerateTelemetry();
            TIS.Sensor68 = GenerateTelemetry();
            TIS.Sensor69 = GenerateTelemetry();
            TIS.Sensor70 = GenerateTelemetry();
            TIS.Sensor71 = GenerateTelemetry();
            TIS.Sensor72 = GenerateTelemetry();
            TIS.Sensor73 = GenerateTelemetry();
            TIS.Sensor74 = GenerateTelemetry();
            TIS.Sensor75 = GenerateTelemetry();
            TIS.Sensor76 = GenerateTelemetry();
            TIS.Sensor77 = GenerateTelemetry();
            TIS.Sensor78 = GenerateTelemetry();
            TIS.Sensor79 = GenerateTelemetry();
            TIS.Sensor80 = GenerateTelemetry();
            TIS.Sensor81 = GenerateTelemetry();
            TIS.Sensor82 = GenerateTelemetry();
            TIS.Sensor83 = GenerateTelemetry();
            TIS.Sensor84 = GenerateTelemetry();
            TIS.Sensor85 = GenerateTelemetry();
            TIS.Sensor86 = GenerateTelemetry();
            TIS.Sensor87 = GenerateTelemetry();
            TIS.Sensor88 = GenerateTelemetry();
            TIS.Sensor89 = GenerateTelemetry();
            TIS.Sensor90 = GenerateTelemetry();
            TIS.Sensor91 = GenerateTelemetry();
            TIS.Sensor92 = GenerateTelemetry();
            TIS.Sensor93 = GenerateTelemetry();
            TIS.Sensor94 = GenerateTelemetry();
            TIS.Sensor95 = GenerateTelemetry();
            TIS.Sensor96 = GenerateTelemetry();
            TIS.Sensor97 = GenerateTelemetry();
            TIS.Sensor98 = GenerateTelemetry();
            TIS.Sensor99 = GenerateTelemetry();
            TIS.Sensor100 = GenerateTelemetry();

        }

        public long AverageTelemetry(TelemetryInformationClass TIC)
        {
            ///do some kind of fake operation to everage and return the middle number
            return TIC.Sensor50;
        }

        public long AverageTelemetry(ref TelemetryInformationStruct TIS)
        {
            ///do some kind of fake operation to average and return the middle number
            return TIS.Sensor50;
        }


        private long GenerateTelemetry()
        {
            
            Random rnd = new Random();
            byte[] buf = new byte[8];
            rnd.NextBytes(buf);
            long LongRand = (long)BitConverter.ToInt64(buf, 0);
               
            return (LongRand);
        }

    }
}
