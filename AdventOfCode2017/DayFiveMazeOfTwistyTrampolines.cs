using AdventOfCode2017.Helpers;
using System.Linq;

namespace AdventOfCode2017
{
    public static class DayFiveMazeOfTwistyTrampolines
    {
        /// <summary>
        /// Gets the number of steps to come out from maze.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns>Step count.</returns>
        public static int GetNumberOfStepsToComeOutFromMaze(int[] steps)
        {
            int stepCount = 0;
            int currentPosition = 0;

            while (currentPosition < steps.Count())
            {
                int previousLocation = currentPosition;

                currentPosition += steps[currentPosition];

                steps[previousLocation] = steps[previousLocation] + 1;

                stepCount++;
            }

            return stepCount;
        }

        /// <summary>
        /// Gets the number of steps to come out from maze.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>step count.</returns>
        public static int GetNumberOfStepsToComeOutFromMaze(string fileName)
        {
            string path = ReadFromTextFile.GetFilePath(fileName);

            string[] dataString = ReadFromTextFile.GetAllLines(path);
            int[] data = dataString.Select(int.Parse).ToArray();

            return GetNumberOfStepsToComeOutFromMaze(data);
        }
    }
}
