using System;
using System.Linq;

namespace StringCalculator
{
    public static class Calculator
    {
        /// <summary>
        /// returns the sum of a delimiter seperated string of numbers
        /// </summary>
        /// <param name="numbers">delimiter seperated string of numbers</param>
        /// <returns>sum of numbers</returns>
        public static int Add(string numbers)
        {
            var delemiters = "\n,";

            if (string.IsNullOrEmpty(numbers))
                return 0;

            if (numbers.Contains("//["))
            {
                int posLF = numbers.IndexOf("\n");
                delemiters += numbers.Substring(3, posLF - 4);
                //delemiters += numbers[2];
                numbers = numbers.Substring(posLF + 1);
            }
            else if (numbers.Contains("//"))
            {
                delemiters += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }
            var items = numbers.Split(delemiters.ToCharArray());

            if (items.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException();

            var integers = items.Select(x => int.Parse(x));
            var negatives = integers.Where(x => x < 0);

            if (negatives.Count() > 0)
            {
                var message = $"Negatives not allowed: {string.Join(",", negatives)}";
                throw new Exception(message);
            }

            return items
            .Select(x => int.Parse(x)).Sum();
        }
    }
}
