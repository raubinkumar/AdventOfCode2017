using System;
using System.Collections.Generic;

namespace AdventOfCode2017
{
    public static class DayThreeSpiralMemory
    {
        /// <summary>
        /// Gets the distance in spiral memory.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The manhattan position in spiral memory. </returns>
        public static int GetDistanceInSpiralMemory(int number)
        {
            double squareRoot = Math.Sqrt(number);

            bool isWholeNumber = squareRoot == (int)squareRoot;

            int maxDistance = 0;

            if (isWholeNumber)
            {
                return (int)squareRoot - 1;
            }
            else
            {
                maxDistance = (int)Math.Floor(squareRoot);
            }

            int previousFullSpiralMax = (int)Math.Pow((maxDistance - 1), 2);

            List<int> maxDistanceNumbers = new List<int>();
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 2);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 3);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 4);

            List<int> minDistanceNumbers = new List<int>();
            foreach (int max in maxDistanceNumbers)
            {
                minDistanceNumbers.Add(max - maxDistance / 2);
            }

            int immediateMax = GetImmediateMaxDigit(maxDistanceNumbers, number);
            int immediatePreviousMin = GetImmediatePreviousMinDigit(minDistanceNumbers, number);

            if (immediateMax - immediatePreviousMin > maxDistance)
            {
                return immediateMax - number;
            }
            else
            {
                return maxDistance - (immediateMax - number);
            }
        }

        /// <summary>
        /// Gets the immediate previous minimum digit.
        /// </summary>
        /// <param name="minDistanceNumbers">The minimum distance numbers.</param>
        /// <param name="number">The number.</param>
        /// <returns>The immediate minimum distance number with respect to target number</returns>
        private static int GetImmediatePreviousMinDigit(List<int> minDistanceNumbers, int number)
        {
            minDistanceNumbers.Reverse();

            foreach (int min in minDistanceNumbers)
            {
                if (min < number)
                {
                    return min;
                }
            }

            return 0;
        }

        /// <summary>
        /// Gets the immediate maximum digit.
        /// </summary>
        /// <param name="maxDistanceNumbers">The maximum distance numbers.</param>
        /// <param name="number">The number.</param>
        /// <returns>The immediate max distance positioned number from target number.</returns>
        private static int GetImmediateMaxDigit(List<int> maxDistanceNumbers, int number)
        {
            foreach (int max in maxDistanceNumbers)
            {
                if (max > number)
                {
                    return max;
                }
            }

            return 0;
        }
    }
}
