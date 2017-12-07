using AdventOfCode2017.Helpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class DayTwoCorruptionChecksum
    {
        /// <summary>
        /// Gets the corruption checksum.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Running sum.</returns>
        public static int GetCorruptionChecksum(string[] data)
        {
            int runningSum = 0;

            foreach (string st in data)
            {
                int[] rowData = GetRowData(st);

                runningSum += rowData.Max() - rowData.Min();
            }

            return runningSum;
        }

        /// <summary>
        /// Gets the row data.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns>Row data.</returns>
        private static int[] GetRowData(string st)
        {
            int[] rowData;

            if (st.Contains("\t"))
            {
                rowData = Regex.Split(st, "\t").Select(int.Parse).ToArray();
            }
            else
            {
                rowData = Regex.Split(st, " ").Select(int.Parse).ToArray();
            }

            return rowData;
        }

        /// <summary>
        /// Gets the corruption checksum from text file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Running sum.</returns>
        public static int GetCorruptionChecksumFromTextFile(string fileName)
        {
            string dataPath = ReadFromTextFile.GetFilePath(fileName);

            string[] data = ReadFromTextFile.GetAllLines(dataPath);

            return GetCorruptionChecksum(data);
        }
    }
}
