using AdventOfCode2017.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017
{
    public static class DayFourPassphrases
    {
        /// <summary>
        /// Gets the valid passphrases.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Count of Valid paraphrases.</returns>
        public static int GetValidPassphrases(string[] data)
        {
            int runningSum = 0;
            List<string> rowData = new List<string>();

            foreach (string st in data)
            {
                if (st.Contains("\t"))
                {
                    rowData = Regex.Split(st, "\t").ToList();
                }
                else
                {
                    rowData = Regex.Split(st, " ").ToList();
                }

                if (rowData.GroupBy(x => x).Where(g => g.Count() > 1).Count() == 0)
                {
                    runningSum += 1;
                }
            }


            return runningSum;
        }

        /// <summary>
        /// Gets the valid passphrases.
        /// </summary>
        /// <param name="textFilepath">The text filepath.</param>
        /// <returns>Count of Valid paraphrases.</returns>
        public static int GetValidPassphrases(string textFilepath)
        {
            string dataPath = ReadFromTextFile.GetFilePath(textFilepath);

            string[] data = ReadFromTextFile.GetAllLines(dataPath);

            return GetValidPassphrases(data);
        }
    }
}
