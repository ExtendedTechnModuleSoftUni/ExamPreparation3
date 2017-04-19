namespace _03.RageQuit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class RageQuit
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().ToUpper();

            var regex = new Regex(@"([^\d]+)(\d+)");
            var matches = regex.Matches(inputLine);
            var finalString = new StringBuilder();
            var uniqueSymbols = new HashSet<char>();

            foreach (Match match in matches)
            {
                var currentString = match.Groups[1].ToString();
                var count = int.Parse(match.Groups[2].ToString());

                if (count > 0)
                {
                    foreach (var symbol in currentString)
                    {
                        uniqueSymbols.Add(symbol);
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    finalString.Append(currentString);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(finalString.ToString());
        }
    }
}
