using AdventOfCode2017.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    public static class DayEightRegisters
    {
        /// <summary>
        /// Gets the lagest register value.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="highestValueHeld">The highest value held.</param>
        /// <returns>The largest value from registers.</returns>
        public static int GetLagestRegisterValue(string fileName, out int highestValueHeld)
        {
            string fullPath = ReadFromTextFile.GetFilePath(fileName);
            string[] dataString = ReadFromTextFile.GetAllLines(fullPath);

            return GetLagestRegisterValue(dataString, out highestValueHeld);
        }

        /// <summary>
        /// Gets the lagest register value.
        /// </summary>
        /// <param name="instructions">The instructions.</param>
        /// <param name="highestValueHeld">The highest value held.</param>
        /// <returns>The largest value from registers. </returns>
        public static int GetLagestRegisterValue(string[] instructions, out int highestValueHeld)
        {
            highestValueHeld = 0;
            // List contains register name, incremental value, Condition {register name on whhich condition is, operration and value for condition}.
            List<Tuple<string, int, string, string, int>> instructionList = new List<Tuple<string, int, string, string, int>>();
            Dictionary<string, int> registers = new Dictionary<string, int>();
            foreach (string instruction in instructions)
            {
                string[] rowData = DataHelper.GetDataAsStringArray(instruction);

                int incrementalValue = rowData[1] == "inc" ? int.Parse(rowData[2]) : -int.Parse(rowData[2]);

                instructionList.Add(new Tuple<string, int, string, string, int>(rowData[0], incrementalValue, rowData[4], rowData[5], int.Parse(rowData[6])));

                if (!registers.ContainsKey(rowData[0]))
                {
                    registers.Add(rowData[0], 0);
                }
            }

            foreach (var instruction in instructionList)
            {
                // get the validity of instruction
                if (Compare(instruction.Item4, registers[instruction.Item3], instruction.Item5))
                {
                    registers[instruction.Item1] += instruction.Item2;
                    if (highestValueHeld < registers[instruction.Item1])
                    {
                        highestValueHeld = registers[instruction.Item1];
                    }
                }
            }

            return registers.Values.Max();
        }

        /// <summary>
        /// Compares the specified op.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="op">The op.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>True if comaprision is valid.</returns>
        /// <exception cref="ArgumentException">Invalid comparison operator: {0}</exception>
        public static bool Compare<T>(string op, T left, T right) where T : IComparable<T>
        {
            switch (op)
            {
                case "<": return left.CompareTo(right) < 0;
                case ">": return left.CompareTo(right) > 0;
                case "<=": return left.CompareTo(right) <= 0;
                case ">=": return left.CompareTo(right) >= 0;
                case "==": return left.Equals(right);
                case "!=": return !left.Equals(right);
                default: throw new ArgumentException("Invalid comparison operator: {0}", op);
            }
        }
    }
}
