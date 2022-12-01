using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public static class StringHelpers
    {
        /// <summary>
        /// converts a string of comma separated list of numbers into collection of ints
        /// </summary>
        /// <param name="input">string of comma separated list of numbers</param>
        /// <returns>collection of ints</returns>
        public static IEnumerable<int> StringToInts(string input)
        {
            try
            {
                string[] splitInput = input.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var output = new List<int>();
                foreach (var numberString in splitInput)
                {
                    output.Add(int.Parse(numberString));
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
