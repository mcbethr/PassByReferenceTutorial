using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
    public class TheBasics
    {




        public int AddTwoNumbersByValue(int number1, int number2)
        {
            
            return number1 + number2;

        }






        public void AddTwoNumbersByReference(ref int number1, ref int number2)
        {
            number1 = number1 + number2;
        }








        public void PassingViaIn(ref int finalNumber, in int number1, in int number2)
        {
            finalNumber = number1 + number2;
            ///Cant do this
            //number1 = number1 + number2;
        }





        public void PassingViaOut(in int DoubleNumber, out int result)
        {
            result = DoubleNumber * 2;
        }



        public void AdjustPresssure(ref int EnginePressure, in int RequiredPressure, out STABenums.FaultStatus fault)
        {
            if (EnginePressure > RequiredPressure)
            {
                IncreasePressure(ref EnginePressure, in RequiredPressure, out fault);
            }
            else if (EnginePressure < RequiredPressure)
            {
                DecreasePressure(ref EnginePressure, in RequiredPressure, out fault);
            }
            else
            {
                //nothing to do here.
                EnginePressure = RequiredPressure;
                fault = STABenums.FaultStatus.Ok;
            }

        }



        private void IncreasePressure(ref int EnginePressure, in int RequiredPressure, out STABenums.FaultStatus fault)
        {
            ///Code to increase pressure and check for fault.
            ///Always succeeds
            EnginePressure = RequiredPressure;
            fault = STABenums.FaultStatus.Ok;
        }

        private void DecreasePressure(ref int EnginePressure, in int RequiredPressure, out STABenums.FaultStatus fault)
        {
            ///Code to decrease pressure and check for fault.
            ///Always succeeds
            EnginePressure = RequiredPressure;
            fault = STABenums.FaultStatus.Ok;
        }

        private PressureResults HowYouWouldReallyDoIt(PressureResults toInspect)
        {
            ///Fake getting the information
            toInspect.FinalPressure = 40;
            toInspect.Fault = STABenums.FaultStatus.Ok;

            return toInspect;
        }

        private void TryParseExample()
        {

            string myString = "123fred";
            int result;
            bool success = int.TryParse(myString, out result);

        }

    }

    public class PressureResults
    {
        public int IncomingPressure { get; set; }

        public int FinalPressure {get;set;}

        public int RequiredPressure { get; }

        public STABenums.FaultStatus Fault { get; set; }

        public PressureResults(int RequiredPressure)
        {
            this.RequiredPressure = RequiredPressure;
        }
    }






 
}
