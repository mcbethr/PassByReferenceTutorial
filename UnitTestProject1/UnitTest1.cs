using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutAndRefTutorial;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestAddTwoNumbers()
        {
            YouCantDoThis Dont = new YouCantDoThis();

            int number1 = 1;
            int number2 = 2;

            ///Add two numbers and return
            int result = Dont.AddTwoNumbers(number1, number2);

            Assert.AreEqual(3, result);

            Dont.AddTwoNumbers(ref number1, ref number2);
            Assert.AreEqual(3, number1);


        }

        [TestMethod]
        public void AddtwoNumbersByValue()
        {
            int number1 = 1;
            int number2 = 2;
            int answer;

            TheBasics B = new TheBasics();

            answer = B.AddTwoNumbersByValue(number1, number2);

            Assert.AreEqual(3, answer);

        }


        [TestMethod]
        public void AddtwoNumbersByReference()
        {
            int number1 = 1;
            int number2 = 2;

            TheBasics B = new TheBasics();

            B.AddTwoNumbersByReference(ref number1, ref number2);

            Assert.AreEqual(3, number1);

        }

    }
}
