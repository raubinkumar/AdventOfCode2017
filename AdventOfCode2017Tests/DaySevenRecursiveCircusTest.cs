using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DaySevenRecursiveCircusTest
    {
        [TestMethod]
        public void DaySevenBothPartTestMethod()
        {
            string bottomprogramName = DaySevenRecursiveCircus.GetBottomProgramName("Day7Data.txt", out int correctWeight);
            Assert.AreEqual("vvsvez", bottomprogramName);
            Assert.AreEqual(362, correctWeight);
        }
    }
}
