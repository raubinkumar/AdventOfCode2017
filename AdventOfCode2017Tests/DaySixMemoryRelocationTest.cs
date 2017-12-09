using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DaySixMemoryRelocationTest
    {
        [TestMethod]
        public void DaySixPartOneTestMethod1()
        {
            int cycle;
            int returnedData = DaySixMemoryRelocation.GetRedistributionCycle("Day6Data.txt", out cycle);
            Assert.AreEqual(3156, returnedData);
        }

        [TestMethod]
        public void DaySixPartOneTestMethod2()
        {
            int cycle;
            int[] data = new int[4] { 0, 2, 7, 0 };
            int returnedData = DaySixMemoryRelocation.GetRedistributionCycle(data, out cycle);
            Assert.AreEqual(5, returnedData);
            Assert.AreEqual(4, cycle);
        }
    }
}
