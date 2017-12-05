using AdventOfCode2017;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017Tests
{
    [TestClass]
    public class DayOneInverseCaptchaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int returnValue = DayOneInverseCaptcha.ReturnSumOfAdjacentMatchingDigit("1122");
            Assert.AreEqual(3, returnValue);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int returnValue = DayOneInverseCaptcha.ReturnSumOfAdjacentMatchingDigit("1111");
            Assert.AreEqual(4, returnValue);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int returnValue = DayOneInverseCaptcha.ReturnSumOfAdjacentMatchingDigit("1234");
            Assert.AreEqual(0, returnValue);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int returnValue = DayOneInverseCaptcha.ReturnSumOfAdjacentMatchingDigit("91212129");
            Assert.AreEqual(9, returnValue);
        }
    }
}
