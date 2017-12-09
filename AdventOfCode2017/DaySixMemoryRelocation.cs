using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class DaySixMemoryRelocation
    {
        #region Part 1 and Part 2(Out parameter is part 2)

        /// <summary>
        /// Gets the redistribution cycle. (out is for part 2)
        /// </summary>
        /// <param name="dataArray">The data array.</param>
        /// <param name="cycle">The cycle.</param>
        /// <returns></returns>
        public static int GetRedistributionCycle(int[] dataArray, out int cycle)
        {
            int[] data = dataArray;
            int length, maxNumber, maxIndex;
            List<int[]> dataList = new List<int[]>();
            dataList.Add(data);
            int foundSequencePosition;
            while (true)
            {
                foundSequencePosition = 0;
                bool found = false;
                length = data.Length;
                maxNumber = data.Max();
                maxIndex = Array.IndexOf(data, maxNumber);


                int distribution = (int)Math.Floor((double)(maxNumber / length));
                int mod = maxNumber % length;

                int[] afterRedistribution = data.Select(n => n + distribution).ToArray();
                afterRedistribution[maxIndex] = distribution;

                int nextIndex = maxIndex + 1;
                for (int i = 0; i < mod; i++)
                {
                    if (nextIndex > length - 1)
                    {
                        nextIndex = 0;
                    }

                    afterRedistribution[nextIndex] = afterRedistribution[nextIndex] + 1;
                    nextIndex++;
                }
                foreach (int[] array in dataList)
                {
                    if (array.SequenceEqual(afterRedistribution))
                    {
                        found = true;
                        break;
                    }
                    foundSequencePosition++;
                }

                if (!found)
                {
                    dataList.Add(afterRedistribution);
                    data = afterRedistribution;
                }
                else
                {
                    break;
                }
            }
            cycle = dataList.Count() - foundSequencePosition;
            return dataList.Count();
        }

        /// <summary>
        /// Gets the redistribution cycle.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="cycle">The cycle.</param>
        /// <returns></returns>
        public static int GetRedistributionCycle(string fileName, out int cycle)
        {
            string path = ReadFromTextFile.GetFilePath(fileName);
            string dataStrings = ReadFromTextFile.GetString(path);
            return GetRedistributionCycle(DataHelper.GetDataAsIntegerArray(dataStrings), out cycle);
        }
        #endregion
    }
}
