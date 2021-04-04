using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {


            //long Processing1Time = RunClassTelemetry();
            //long Processing2Time = RunStructureTelemetry();

            ///Generate Telemetry for list of classes
            //List<TelemetryData.TelemetryInformationClass> TICList = GenerateTenTelemetryClasses();

            //Generate telemetry for an array of structures
            TelemetryData.TelemetryInformationStruct TIS = new TelemetryData.TelemetryInformationStruct();
            TelemetryData.TelemetryInformationStruct[] TISArray = new TelemetryData.TelemetryInformationStruct[10];
            GenerateTenTelemetryStructures(ref TISArray, ref TIS);

            //Console.WriteLine("(Class    ): " + Processing1Time + " milliseconds.");
            //Console.WriteLine("(Structure): " + Processing2Time + " milliseconds.");


        }

        public static long RunClassTelemetry()
        {
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            TelemetryData.TelemetryInformationClass TIC = new TelemetryData.TelemetryInformationClass();
            Telemetry T = new Telemetry();
            TIC = T.FillTelemetry(TIC);


            long AverageValue = T.AverageTelemetry(TIC);

            stopwatch1.Stop();
            return stopwatch1.ElapsedMilliseconds;
        }

        public static long RunStructureTelemetry()
        {
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            TelemetryData.TelemetryInformationStruct TIC = new TelemetryData.TelemetryInformationStruct();
            Telemetry T = new Telemetry();
            T.FillTelemetry(ref TIC);


            long AverageValue = T.AverageTelemetry(ref TIC);

            stopwatch2.Stop();
            return stopwatch2.ElapsedMilliseconds;
        }

        public static List<TelemetryData.TelemetryInformationClass> GenerateTenTelemetryClasses()
        {
            TelemetryData.TelemetryInformationClass TIC = new TelemetryData.TelemetryInformationClass();
            Telemetry T = new Telemetry();

            List<TelemetryData.TelemetryInformationClass> TelemetryList = new List<TelemetryData.TelemetryInformationClass>();

            for (int i=0; i<10; i++)
            {
                TelemetryList.Add(T.FillTelemetry(TIC));
            }

            return TelemetryList;

        }

        public static void GenerateTenTelemetryStructures(ref TelemetryData.TelemetryInformationStruct[] TISArray, ref TelemetryData.TelemetryInformationStruct TIS)
        {
 
            Telemetry T = new Telemetry();

            for (int i = 0; i < 10; i++)
            {
               T.FillTelemetry(ref TIS);
                TISArray[i] = TIS;
                
            }

            

        }
    }
}
