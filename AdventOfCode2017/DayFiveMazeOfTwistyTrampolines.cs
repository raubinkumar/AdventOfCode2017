using AdventOfCode2017.Helpers;
using System.Linq;

namespace AdventOfCode2017
{
    public static class DayFiveMazeOfTwistyTrampolines
    {
        #region Part 1 and Part 2
        /// <summary>
        /// Gets the number of steps to come out from maze.
        /// </summary>
        /// <param name="steps">The steps.</param>
        /// <returns>Step count.</returns>
        public static int GetNumberOfStepsToComeOutFromMaze(int[] steps, PuzzlePart part = PuzzlePart.One)
        {
            int stepCount = 0;
            int currentPosition = 0;

            while (currentPosition < steps.Count())
            {
                int previousLocation = currentPosition;

                currentPosition += steps[currentPosition];

                if (part == PuzzlePart.Two && steps[previousLocation] > 2)
                {
                    steps[previousLocation] = steps[previousLocation] - 1;
                }
                else
                {
                    steps[previousLocation] = steps[previousLocation] + 1;
                }

                stepCount++;
            }

            return stepCount;
        }

        /// <summary>
        /// Gets the number of steps to come out from maze.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>step count.</returns>
        public static int GetNumberOfStepsToComeOutFromMaze(string fileName, PuzzlePart part = PuzzlePart.One)
        {
            string path = ReadFromTextFile.GetFilePath(fileName);

            string[] dataString = ReadFromTextFile.GetAllLines(path);
            int[] data = dataString.Select(int.Parse).ToArray();

            return GetNumberOfStepsToComeOutFromMaze(data, part);
        }

        #endregion

    }

    #region Emum

    public enum PuzzlePart
    {
        One,
        Two
    }

    #endregion
}
