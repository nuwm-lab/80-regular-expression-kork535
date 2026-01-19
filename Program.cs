using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace LabWork
{
    public class NumberExtractor
    {
        private const string Pattern = @"\((\d+)\)|\[(\d+)\]";

        public List<string> ExtractNumbers(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return new List<string>();
            }

            List<string> results = new List<string>();
            MatchCollection matches = Regex.Matches(inputText, Pattern);

            foreach (Match match in matches)
            {
                string number = match.Groups[1].Success
                    ? match.Groups[1].Value
                    : match.Groups[2].Value;
                results.Add(number);
            }

            return results;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Введіть текст для пошуку чисел у дужках");

            string userInput = Console.ReadLine();

            NumberExtractor extractor = new NumberExtractor();
            List<string> foundNumbers = extractor.ExtractNumbers(userInput);

            if (foundNumbers.Count > 0)
            {
                Console.WriteLine("Знайдені числа:");
                foreach (string number in foundNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("У введеному тексті чисел у дужках не знайдено.");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}