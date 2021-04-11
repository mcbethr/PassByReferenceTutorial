using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static OutAndRefTutorial.TelemetryData;

namespace OutAndRefTutorial
{
    public class Telemetry
    {


        public static long GenerateTelemetry()
        {

            Random rnd = new Random();

            byte[] buf = new byte[8];
            rnd.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return rnd.Next(int.MinValue, int.MaxValue);

        }

        public static void FillTelemetryClassByVal(TelemetryClass TC)
        {

            TC.one = Telemetry.GenerateTelemetry();
            TC.two = Telemetry.GenerateTelemetry();

        }

        public static void FillTelemetryClassByRef(ref TelemetryClass TC)
        {


            TC.one = Telemetry.GenerateTelemetry();
            TC.two = Telemetry.GenerateTelemetry();

        }

        public static TelemetryStruct FillTelemetryStructByVal(TelemetryStruct TS)
        {
            TS.one = Telemetry.GenerateTelemetry();
            TS.two = Telemetry.GenerateTelemetry();

            return TS;
        }

        public static void FillTelemetryStructByRef(ref TelemetryStruct TS)
        {
            TS.one = Telemetry.GenerateTelemetry();
            TS.two = Telemetry.GenerateTelemetry();
        }

        public static TelemetryClass AverageTelemetryClassByVal(TelemetryClass TC)
        {
            TC.Average = (TC.one + TC.two) / 2;
            return TC;
        }


        public static TelemetryClass AverageTelemetryClassByValNew(TelemetryClass TC)
        {
            //You are passing a copy of the reference but this create a new reference
            //TC = new TelemetryClass();
            TelemetryClass TCn = new TelemetryClass();
            TCn.one = TC.one;
            TCn.two = TC.two;
            TCn.Average = (TC.one + TC.two) / 2;
            return TCn;
        }

        public static void AverageTelemetryClassByRef(ref TelemetryClass TC)
        {
            TC.Average = (TC.one + TC.two) / 2;
        }

        public static void SwapTelemetryClassByRef(ref TelemetryClass TC1, ref TelemetryClass TC2)
        {
            //TelemetryClass TMP = TC1;
            TC1 = TC2;
            //TC2 = TMP;
        }

        public static TelemetryClass ReturnTC1()
        {
            TelemetryClass TC1 = new TelemetryClass();
            TC1.one = 1;
            TC1.two = 2;
            return TC1;
        }

        public static TelemetryClass ReturnTC2()
        {
            TelemetryClass TC2 = new TelemetryClass();
            TC2.one = 1;
            TC2.two = 2;
            return TC2;
        }



        public static TelemetryStruct AverageTelemetryStructByVal(TelemetryStruct TS)
        {
            TS.Average = (TS.one + TS.two) / 2;
            return TS;
        }

        public static void AverageTelemetryStructByRef(ref TelemetryStruct TS)
        {
            TS.Average = (TS.one + TS.two) / 2;

        }


    }
}
