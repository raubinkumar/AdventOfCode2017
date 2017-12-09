using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Helpers
{
    public static class DataHelper
    {
        /// <summary>
        /// Gets the row data.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns>Row data.</returns>
        public static int[] GetDataAsIntegerArray(string st)
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
        /// Gets the row data.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns>Row data.</returns>
        public static string[] GetDataAsStringArray(string st)
        {
            string[] rowData;

            if (st.Contains("\t"))
            {
                rowData = Regex.Split(st, "\t").ToArray();
            }
            else
            {
                rowData = Regex.Split(st, " ").ToArray();
            }

            return rowData;
        }

        /// <summary>
        /// Gets the row data.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns>Row data.</returns>
        public static string[] GetSortedStringArray(string[] stringArray)
        {
            List<string> strings = new List<string>();

            foreach (string st in stringArray)
            {
                char[] charArray = st.ToCharArray();
                Array.Sort(charArray);
                strings.Add(new string(charArray));
            }

            return strings.ToArray();
        }
    }
}
