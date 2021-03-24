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

    }
}
