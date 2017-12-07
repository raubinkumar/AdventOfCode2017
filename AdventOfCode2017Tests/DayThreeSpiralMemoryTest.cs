using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DayThreeSpiralMemoryTest
    {
        [TestMethod]
        public void DayThreeTestMethod1()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(22);
            Assert.AreEqual(3, position);
        }

        [TestMethod]
        public void DayThreeTestMethod2()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(1);
            Assert.AreEqual(0, position);
        }

        [TestMethod]
        public void DayThreeTestMethod3()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(4);
            Assert.AreEqual(1, position);
        }

        [TestMethod]
        public void DayThreeTestMethod4()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(22);
            Assert.AreEqual(3, position);
        }

        [TestMethod]
        public void DayThreeTestMethod5()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(24);
            Assert.AreEqual(3, position);
        }

        [TestMethod]
        public void DayThreeTestMethod6()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(25);
            Assert.AreEqual(4, position);
        }

        [TestMethod]
        public void DayThreeTestMethod7()
        {
            int position = DayThreeSpiralMemory.GetDistanceInSpiralMemory(368078);
            Assert.AreEqual(371, position);
        }
    }
}
