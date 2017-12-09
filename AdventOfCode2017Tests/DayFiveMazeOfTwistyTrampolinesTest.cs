using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DayFiveMazeOfTwistyTrampolinesTest
    {
        #region Part 1
        [TestMethod]
        public void DayFiveTestMethod1()
        {
            int[] steps = new int[6] { 0, 3, 0, 1, -3, 1 };
            int count = DayFiveMazeOfTwistyTrampolines.GetNumberOfStepsToComeOutFromMaze(steps);
            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void DayFiveTestMethod2()
        {
            int count = DayFiveMazeOfTwistyTrampolines.GetNumberOfStepsToComeOutFromMaze("Day5Data.txt");
            Assert.AreEqual(375042, count);
        }
        #endregion

        #region Part 2
        [TestMethod]
        public void DayFiveTestMethod3()
        {
            int[] steps = new int[5] { 0, 3, 0, 1, -3 };
            int count = DayFiveMazeOfTwistyTrampolines.GetNumberOfStepsToComeOutFromMaze(steps, PuzzlePart.Two);
            Assert.AreEqual(10, count);
        }

        [TestMethod]
        public void DayFiveTestMethod4()
        {
            int count = DayFiveMazeOfTwistyTrampolines.GetNumberOfStepsToComeOutFromMaze("Day5Data.txt", PuzzlePart.Two);
            Assert.AreEqual(28707598, count);
        }
        #endregion
    }
}
