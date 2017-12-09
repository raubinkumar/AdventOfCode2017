using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{

    public static class DayThreeSpiralMemory
    {
        #region Day 3 Part 1

        /// <summary>
        /// Gets the distance in spiral memory.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The manhattan position in spiral memory. </returns>
        public static int GetDistanceInSpiralMemory(int number)
        {
            int maxDistance = GetMaxDistance(number);
            if (maxDistance == (int)(Math.Sqrt(number)) - 1)
            {
                return maxDistance;
            }
            List<int> maxDistanceNumbers = GetMaxdistanceNumbers(maxDistance);

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

        #endregion

        #region Day 3 Part 2
        /// <summary>
        /// Gets the next number from stressed grid.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static int GetNextNumberFromStressedGrid(int number)
        {
            int numberToReturn = 0;

            List<Tuple<Tuple<int, int>, int>> grid = new List<Tuple<Tuple<int, int>, int>>();
            Tuple<int, int> nextCoordinate = new Tuple<int, int>(0, 0);
            Tuple<Tuple<int, int>, int> gridNode = new Tuple<Tuple<int, int>, int>(nextCoordinate, 1);
            grid.Add(gridNode);
            int spiralLocation = 1;
            while (true)
            {
                spiralLocation++;
                int maxDistance = GetMaxDistance(spiralLocation);
                List<int> cornerLocations = GetMaxdistanceNumbers(maxDistance);
                nextCoordinate = GetNextCoordinate(cornerLocations, spiralLocation, maxDistance);

                int nextNodeValue = GetNextNodeValue(grid, nextCoordinate);

                Tuple<Tuple<int, int>, int> newNode = new Tuple<Tuple<int, int>, int>(nextCoordinate, nextNodeValue);
                grid.Add(newNode);

                if (nextNodeValue > number)
                {
                    numberToReturn = nextNodeValue;
                    break;
                }
            }

            return numberToReturn;
        }

        /// <summary>
        /// Gets the next node value.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <param name="nextCoordinate">The next coordinate.</param>
        /// <returns></returns>
        private static int GetNextNodeValue(List<Tuple<Tuple<int, int>, int>> grid, Tuple<int, int> nextCoordinate)
        {
            int nodeValue = 0;
            List<Tuple<int, int>> adjecentCoordinates = new List<Tuple<int, int>>();
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 + 1, nextCoordinate.Item2));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 + 1, nextCoordinate.Item2 + 1));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1, nextCoordinate.Item2 + 1));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 - 1, nextCoordinate.Item2 + 1));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 - 1, nextCoordinate.Item2));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 - 1, nextCoordinate.Item2 - 1));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1, nextCoordinate.Item2 - 1));
            adjecentCoordinates.Add(new Tuple<int, int>(nextCoordinate.Item1 + 1, nextCoordinate.Item2 - 1));

            List<Tuple<int, int>> filledAdjecentGrid = grid.Select(c => c.Item1).Intersect(adjecentCoordinates).ToList();
            foreach (Tuple<int, int> coordinate in filledAdjecentGrid)
            {
                nodeValue += grid.Where(c => c.Item1 == coordinate).Select(n => n.Item2).FirstOrDefault();
            }


            return nodeValue;
        }


        /// <summary>
        /// Gets the next coordinate.
        /// </summary>
        /// <param name="firstMaxDistancedNumber">The first maximum distanced number.</param>
        /// <param name="location">The location.</param>
        /// <param name="maxDistance">The maximum distance.</param>
        /// <returns></returns>
        private static Tuple<int, int> GetNextCoordinate(List<int> cornerLocations, int location, int maxDistance)
        {
            int firstMax = cornerLocations.First();

            if (firstMax == location)
            {
                return new Tuple<int, int>(maxDistance / 2, maxDistance / 2);
            }
            else if ((location - firstMax) == maxDistance)
            {
                return new Tuple<int, int>(-maxDistance / 2, maxDistance / 2);
            }
            else if ((location - firstMax) == maxDistance * 2)
            {
                return new Tuple<int, int>(-maxDistance / 2, -maxDistance / 2);
            }
            else if ((location - firstMax) == maxDistance * 3)
            {
                return new Tuple<int, int>(maxDistance / 2, -maxDistance / 2);
            }
            else
            {
                Direction direction = GetDirection(firstMax, location, maxDistance);
                switch (direction)
                {
                    case Direction.North:
                        return new Tuple<int, int>(maxDistance / 2 - (location - firstMax), maxDistance / 2);
                    case Direction.South:
                        return new Tuple<int, int>(-maxDistance / 2 + (location - (firstMax + 2 * maxDistance)), -maxDistance / 2);
                    case Direction.East:
                        return new Tuple<int, int>(maxDistance / 2, maxDistance / 2 - (firstMax - location));
                    case Direction.West:
                        return new Tuple<int, int>(-maxDistance / 2, maxDistance / 2 - (location - (firstMax + maxDistance)));
                }
            }


            return new Tuple<int, int>(0, 0);
        }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <param name="firstMax">The first maximum.</param>
        /// <param name="location">The location.</param>
        /// <param name="maxDistance">The maximum distance.</param>
        /// <returns></returns>
        private static Direction GetDirection(int firstMax, int location, int maxDistance)
        {
            if (location < firstMax)
            {
                return Direction.East;
            }
            else if ((location - firstMax) < maxDistance)
            {
                return Direction.North;
            }
            else if (location - firstMax < 2 * maxDistance)
            {
                return Direction.West;
            }
            else
            {
                return Direction.South;
            }
        }
        #endregion

        #region Common

        /// <summary>
        /// Gets the maximum distance.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Max distance.</returns>
        private static int GetMaxDistance(int number)
        {
            double squareRoot = Math.Sqrt(number);

            bool isWholeNumber = squareRoot == (int)squareRoot;

            int maxDistance = 0;

            if (isWholeNumber)
            {
                maxDistance = (int)squareRoot - 1;
            }
            else
            {
                maxDistance = (int)Math.Floor(squareRoot);
            }
            if (maxDistance % 2 != 0)
            {
                maxDistance++;
            }

            return maxDistance;
        }

        /// <summary>
        /// Gets the maxdistance numbers.
        /// </summary>
        /// <param name="maxDistance">The maximum distance.</param>
        /// <returns></returns>
        private static List<int> GetMaxdistanceNumbers(int maxDistance)
        {
            int previousFullSpiralMax = (int)Math.Pow((maxDistance - 1), 2);

            List<int> maxDistanceNumbers = new List<int>();
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 2);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 3);
            maxDistanceNumbers.Add(previousFullSpiralMax + maxDistance * 4);

            return maxDistanceNumbers;
        }

        #endregion
    }

    #region Enum
    /// <summary>
    /// Direction enumeration
    /// </summary>
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    #endregion
}
