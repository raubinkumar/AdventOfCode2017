using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DayTwoPartTwoTest
    {
        [TestMethod]
        public void DayTwoPartTwoTestMethod1()
        {
            string[] data = new string[3] { "5 9 2 8", "9 4 7 3", "3 8 6 5" };
            int returnedData = DayTwoPartTwo.GetSumOfEvenlyDivisableValues(data);
            Assert.AreEqual(9, returnedData);
        }

        [TestMethod]
        public void DayTwoPartTwoTestMethod2()
        {
            int returnedData = DayTwoPartTwo.GetSumOfEvenlyDivisableValues("Day2Data2.txt");
            Assert.AreEqual(351, returnedData);
        }
    }
}
