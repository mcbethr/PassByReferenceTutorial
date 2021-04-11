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

            TheBasics basic = new TheBasics();
            int _one = 1;
            int _two = 2;
            
            int answer = basic.AddTwoNumbersByValue(_one, _two);

            basic.AddTwoNumbersByReference(ref _one, ref _two);
            

            //Pass by reference type by value

            TelemetryClass TC = new TelemetryClass();
            TC.one = 2;
            TC.two = 4;
            Telemetry.AverageTelemetryClassByVal(TC);

            //Swap memory locations
            TelemetryClass TC1 = new TelemetryClass();
            TC1.one = 2;
            TC1.two = 4;

            TelemetryClass TC2 = new TelemetryClass();
            TC2.one = 3;
            TC2.two = 5;    
            Telemetry.SwapTelemetryClassByRef(ref TC1, ref TC2);

            //Fill Telemetry Data Class by Value
            TelemetryClass TCv = new TelemetryClass();
            Telemetry.FillTelemetryClassByVal(TCv);
            Telemetry.AverageTelemetryClassByVal(TCv);

            //Fill Telemetry Data Class By Reference
            TelemetryData.TelemetryClass TCr = new TelemetryData.TelemetryClass();
            Telemetry.FillTelemetryClassByRef(ref TCr);
            Telemetry.AverageTelemetryClassByRef(ref TCr);

            //Fill Telemetry Data Class By ReferenceNew 
            TelemetryData.TelemetryClass TCvn = new TelemetryData.TelemetryClass();
            Telemetry.FillTelemetryClassByVal(TCvn);
            TelemetryData.TelemetryClass TCvnResult = Telemetry.AverageTelemetryClassByValNew(TCvn);



            ///Fill Telemetry Data Struct by Value
            TelemetryData.TelemetryStruct TSv = new TelemetryData.TelemetryStruct();
            TSv = Telemetry.FillTelemetryStructByVal(TSv);
            TSv = Telemetry.AverageTelemetryStructByVal(TSv);

            //Fill Telemetry Data Struct by Reference
            TelemetryData.TelemetryStruct TSr = new TelemetryData.TelemetryStruct();
            Telemetry.FillTelemetryStructByRef(ref TSr);
            Telemetry.AverageTelemetryStructByRef(ref TSr);


        }

    }
}
