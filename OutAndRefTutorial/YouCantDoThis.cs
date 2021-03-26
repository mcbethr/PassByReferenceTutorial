using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
    public class YouCantDoThis
    {

        public int AddTwoNumbers(int FirstNumber, int SecondNumber)
        {
            return FirstNumber + SecondNumber;

        }

        public void AddTwoNumbers(ref int FirstNumber, ref int SecondNumber)
        {
            FirstNumber = FirstNumber + SecondNumber;
        }

        /// <summary>
        /// The in, ref, and out keywords are not considered part of the 
        /// method signature for the purpose of overload resolution.
        /// </summary>
        /// <param name="FirstNumber"></param>
        /// <param name="SecondNumber"></param>
        /*
        public void AddTwoNumbers(out int FirstNumber, out int SecondNumber)
        {
            FirstNumber = 1;
            SecondNumber = 2;
            FirstNumber = FirstNumber + SecondNumber;
            SecondNumber = FirstNumber + SecondNumber;

        }
        */


    }
}
