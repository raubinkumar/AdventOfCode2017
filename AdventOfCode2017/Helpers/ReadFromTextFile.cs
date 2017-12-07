using System.IO;

namespace AdventOfCode2017.Helpers
{
    public static class ReadFromTextFile
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>file path.</returns>
        public static string GetFilePath(string fileName)
        {
            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            return solutionPath + "\\AdventOfCode2017\\Data\\" + fileName;
        }

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
