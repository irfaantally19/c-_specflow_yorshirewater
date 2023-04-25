using System;
using System.Linq;

/// <summary>
/// Helper class for support
/// </summary>
namespace SAP.Utilities
{
    public class StepHelpers
    {
        /// <summary>
        /// Replace a string that contains a special characters
        /// </summary>
        /// <param name="stringToReplace"></param>
        /// <returns>Return string type</returns>
        public static string ReplaceString(string stringToReplace)
        {
            return stringToReplace.Replace(" ", "_");
        }

        /// <summary>
        /// Random AlphaNumeric generator
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomStringGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        // <summary>
        /// Random AlphaNumeric generator
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomNumberGenerator(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
