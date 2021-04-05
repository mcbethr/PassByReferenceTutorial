using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using static OutAndRefTutorial.TelemetryData;

namespace OutAndRefTutorial
{
    class Program
    {
        static void Main(string[] args)
        {


            //long SensorAverage1 = RunClassTelemetryByVal();
            //long SensorAverage2 = RunClassTelemetryByRef();
           // long SensorAverage3 = RunStructureTelemetryByRef();
            long SensorAverage4 = RunStructureTelemetryByVal();

            ///Generate Telemetry for list of classes
            //List<TelemetryData.TelemetryInformationClass> TICList = GenerateTenTelemetryClasses();

            //Generate telemetry for an array of structures
            //TelemetryData.TelemetryInformationStruct TIS = new TelemetryData.TelemetryInformationStruct();
            //TelemetryData.TelemetryInformationStruct[] TISArray = new TelemetryData.TelemetryInformationStruct[10];
            //GenerateTenTelemetryStructures(ref TISArray, ref TIS);




        }

        public static long RunClassTelemetryByVal()
        {

            TelemetryData.TelemetryInformationClass TIC = new TelemetryData.TelemetryInformationClass();
            Telemetry T = new Telemetry();
            TIC = T.FillTelemetryWithClass();


            return T.AverageTelemetry(TIC);

        }

        public static long RunClassTelemetryByRef()
        {

            TelemetryData.TelemetryInformationClass TIC = new TelemetryData.TelemetryInformationClass();
            Telemetry T = new Telemetry();
            T.FillTelemetry(ref TIC);


            return T.AverageTelemetry(ref TIC);

        }

        public static long RunStructureTelemetryByRef()
        {

            TelemetryData.TelemetryInformationStruct TIS = new TelemetryData.TelemetryInformationStruct();
            Telemetry T = new Telemetry();
            T.FillTelemetry(ref TIS);


            return T.AverageTelemetry(ref TIS);

        }

        public static long RunStructureTelemetryByVal()
        {

            
            Telemetry T = new Telemetry();
            TelemetryData.TelemetryInformationStruct TISr = T.FillTelemetryWithStruct();
            
            return T.AverageTelemetry(TISr);
                        

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
