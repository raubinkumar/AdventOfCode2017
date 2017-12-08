using AdventOfCode2017.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class DayTwoPartTwo
    {
        public static int GetSumOfEvenlyDivisableValues(string[] data)
        {
            int runningSum = 0;
            foreach (string st in data)
            {
                List<int> dataArray = DataHelper.GetDataAsIntegerArray(st).ToList();
                dataArray.Sort();
                foreach (int i in dataArray)
                {
                    int divisableNumber = dataArray.Where(n => n % i == 0 && n / i != 1).FirstOrDefault();
                    runningSum += divisableNumber / i;
                    if (divisableNumber != 0)
                        break;
                }
            }

            return runningSum;
        }

        public static int GetSumOfEvenlyDivisableValues(string fileName)
        {
            string path = ReadFromTextFile.GetFilePath(fileName);

            string[] dataString = ReadFromTextFile.GetAllLines(path);

            return GetSumOfEvenlyDivisableValues(dataString);
        }
    }
}
