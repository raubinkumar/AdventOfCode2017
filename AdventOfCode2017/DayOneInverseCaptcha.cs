using System;

namespace AdventOfCode2017
{
    /// <summary>
    /// Solution class to advent of code 2017 day 1 
    /// </summary>
    public static class DayOneInverseCaptcha
    {
        public static int ReturnSumOfAdjacentMatchingDigit(string digitString)
        {
            int runningSum = 0;

            char[] charArray = digitString.ToCharArray();
            for (int index = 0; index < charArray.Length - 1; index++)
            {
                if (charArray[index] == charArray[index + 1])
                {
                    runningSum += Convert.ToInt16(charArray[index]) - 48;
                }
            }
            if (charArray[0] == charArray[charArray.Length - 1])
            {
                runningSum += Convert.ToInt16(charArray[0]) - 48;
            }
            return runningSum;
        }
    }
}
