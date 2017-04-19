namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Files
    {
        public static void Main()
        {
            var numberOfFiles = int.Parse(Console.ReadLine());
            var regex = new Regex(@"(.+)\\(.+);(\d+)");
            var dict = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < numberOfFiles; i++)
            {
                var currentFile = Console.ReadLine();

                var match = regex.Match(currentFile);

                var root = match.Groups[1].ToString().Split('\\').First();
                var fileName = match.Groups[2].ToString().Trim();
                var fileSize = long.Parse(match.Groups[3].ToString());

                if (!dict.ContainsKey(root))
                {
                    dict.Add(root, new Dictionary<string, long>());
                }
                if (!dict[root].ContainsKey(fileName))
                {
                    dict[root].Add(fileName, 0L);
                }

                dict[root][fileName] = fileSize;
            }

            var query = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var extension = "." + query[0];
            var neededRoot = query[2];
            var isSomethingPrinted = false;

            if (dict.Keys.Contains(neededRoot))
            {
                foreach (var item in dict[neededRoot].OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (item.Key.Contains(extension))
                    {
                        isSomethingPrinted = true;
                        Console.WriteLine($"{item.Key} - {item.Value} KB");
                    }
                }
            }

            if (!isSomethingPrinted)
            {
                Console.WriteLine("No");
            }
        }
    }
}
