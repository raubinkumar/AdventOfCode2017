using System.IO;

namespace AdventOfCode2017.Helpers
{
    public static class ReadFromTextFile
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>All text.</returns>
        public static string GetString(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Gets all lines.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>returns all lines.</returns>
        public static string[] GetAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

    }
}
