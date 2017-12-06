using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    /// <summary>
    /// Advent of code Day2 Tests
    /// </summary>
    [TestClass]
    public class DayTwoCorruptionChecksumTest
    {
        [TestMethod]
        public void Day2TestMethod1()
        {
            int returnData = DayTwoCorruptionChecksum.GetCorruptionChecksumFromTextFile("Day2Data.txt");
            Assert.AreEqual(48357, returnData);
        }

        [TestMethod]
        public void Day2TestMethod2()
        {
            string[] data = new string[3] { "5 1 9 5", "7 5 3", "2 4 6 8" };
            int returnData = DayTwoCorruptionChecksum.GetCorruptionChecksum(data);
            Assert.AreEqual(18, returnData);
        }
    }
}
