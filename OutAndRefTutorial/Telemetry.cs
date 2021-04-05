using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static OutAndRefTutorial.TelemetryData;

namespace OutAndRefTutorial
{
    public class Telemetry
    {


        public TelemetryInformationClass FillTelemetryWithClass()
        {
            TelemetryInformationClass TIC = new TelemetryInformationClass();
            TIC.Sensor1 = GenerateTelemetry();
            TIC.Sensor2 = GenerateTelemetry();
            TIC.Sensor3 = GenerateTelemetry();
            return TIC;
        }

        public void FillTelemetry(ref TelemetryInformationClass TIC)
        {

            TIC.Sensor1 = GenerateTelemetry();
            TIC.Sensor2 = GenerateTelemetry();
            TIC.Sensor3 = GenerateTelemetry();
        }

        public void FillTelemetry(ref TelemetryInformationStruct TIS)
        {

            TIS.Sensor1 = GenerateTelemetry();
            TIS.Sensor2 = GenerateTelemetry();
            TIS.Sensor3 = GenerateTelemetry();

        }

        public TelemetryInformationStruct FillTelemetryWithStruct()
        {
            TelemetryInformationStruct TIS = new TelemetryInformationStruct();
            TIS.Sensor1 = GenerateTelemetry();
            TIS.Sensor2 = GenerateTelemetry();
            TIS.Sensor3 = GenerateTelemetry();
            return TIS;
        }

        public long AverageTelemetry(TelemetryInformationClass TIC)
        {
            ///do some kind of fake operation to everage and return the middle number
            return TIC.Sensor2;
        }

        public long AverageTelemetry(ref TelemetryInformationClass TIC)
        {
            ///do some kind of fake operation to everage and return the middle number
            return TIC.Sensor2;
        }

        public long AverageTelemetry(ref TelemetryInformationStruct TIS)
        {
            ///do some kind of fake operation to average and return the middle number
            return TIS.Sensor2;
        }

        public long AverageTelemetry(TelemetryInformationStruct TIS)
        {
            ///do some kind of fake operation to average and return the middle number
            return TIS.Sensor2;
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
