namespace _02.CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var commands = Console.ReadLine();

            while (commands != "end")
            {
                var commandParts = commands.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandParts[0])
                {
                    case "reverse":
                        int reverseStart = int.Parse(commandParts[2]);
                        int reverseCount = int.Parse(commandParts[4]);

                        if (reverseStart >= 0 && reverseStart < arr.Count && reverseStart + reverseCount <= arr.Count && reverseCount >= 0)
                        {
                            GetReverseCommand(reverseStart, reverseCount, arr);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;
                    case "sort":
                        int sortStart = int.Parse(commandParts[2]);
                        int sortCount = int.Parse(commandParts[4]);

                        if (sortStart >= 0 && sortStart < arr.Count && sortStart + sortCount <= arr.Count && sortCount >= 0)
                        {
                            GetSortCommand(sortStart, sortCount, arr);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;
                    case "rollLeft":
                        int roolLeftCount = int.Parse(commandParts[1]);

                        if (roolLeftCount < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        else
                        {
                            GetRollLeftCommand(roolLeftCount, arr);
                        }

                        break;
                    case "rollRight":
                        int rollRightCount = int.Parse(commandParts[1]);

                        if (rollRightCount < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        else
                        {
                            GetGetRollRightCommand(rollRightCount, arr);
                        }

                        break;
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        static void GetReverseCommand(int startIndex, int count, List<string> arr)
        {
            arr.Reverse(startIndex, count);
        }

        static void GetSortCommand(int startIndex, int count, List<string> arr)
        {
            arr.Sort(startIndex, count, null);
        }

        static void GetRollLeftCommand(int rollLeft, List<string> arr)
        {
            var rollTimes = rollLeft % arr.Count;

            for (int i = 0; i < rollTimes; i++)
            {
                var firstIndex = arr[0];

                for (int r = 0; r < arr.Count - 1; r++)
                {
                    arr[r] = arr[r + 1];
                }

                arr[arr.Count - 1] = firstIndex;
            }


        }

        static void GetGetRollRightCommand(int rollRight, List<string> arr)
        {
            var rollTimes = rollRight % arr.Count;

            for (int i = 0; i < rollTimes; i++)
            {
                var lastIndex = arr[arr.Count - 1];

                for (int r = arr.Count - 1; r > 0; r--)
                {
                    arr[r] = arr[r - 1];
                }

                arr[0] = lastIndex;
            }
        }
    }
}
