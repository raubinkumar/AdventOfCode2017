using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DayEightRegistersTest
    {
        [TestMethod]
        public void DayEightPartOneAndTwoTestMethod()
        {
            int highestValueHeld;
            int maxValue = DayEightRegisters.GetLagestRegisterValue("Day8Data.txt", out highestValueHeld);
            Assert.AreEqual(5075, maxValue);
            Assert.AreEqual(7310, highestValueHeld);
        }
    }
}
