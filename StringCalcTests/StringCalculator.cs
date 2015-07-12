using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalcTests
{
    public class StringCalculator
    {
        private const string DelimiterMarker = "//";
        public int Add(string numbers)
        {

            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            int sum = 0;
            int parseResult = 0;
            char[] delimiter = { ',' };
            if (numbers.StartsWith(DelimiterMarker))
            {
                int delimiterStart = DelimiterMarker.Length;
                int delimiterLength = numbers.IndexOf('\n');
                
                delimiter = numbers.Substring(delimiterStart, delimiterLength - delimiterStart).ToCharArray();
                numbers = numbers.Substring(4);
            }

            numbers = numbers.Replace("\n", ",");
            string[] split = numbers.Split(delimiter);
            foreach (string item in split)
            {
                bool tryParse = int.TryParse(item, out parseResult);
                if (!tryParse)
                    throw new ArgumentException("Not a number");
                sum += parseResult;
            }

            if (parseResult < 0)
                throw new ArgumentException("negatives not allowed, you passed: " + numbers);

            return sum;

        }

        public StringCalculator()
        {
            
        }
    }
}
