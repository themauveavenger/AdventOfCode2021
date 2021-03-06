using System;
using System.Linq;

namespace AdventOfCode2021.Days
{
    public class Day1 : IDay
    {
        string inputPath = @".\Days\Day1Resources\input.txt";

        public void Run()
        {
            var input = Helpers.ReadFileLines(inputPath).Select(i => Convert.ToInt32(i)).ToArray();
            var depthIncreasedCount = 0;
            for (int i = 1; i < input.Length; i += 1)
            {
                var depth = input[i];
                var prevDepth = input[i - 1];

                if (depth > prevDepth)
                {
                    depthIncreasedCount += 1;
                }
            }

            Console.WriteLine($"depth increased count: {depthIncreasedCount}");
        }

        public void RunPart2()
        {
            var input = Helpers.ReadFileLines(inputPath).Select(i => Convert.ToInt32(i)).ToArray();
            var sumIncreasedCount = 0;
            var prevSum = 0;
            for (int i = 2; i < input.Length; i += 1)
            {
                // get the window, which is current & the previous 2 entries
                var a = input[i - 2];
                var b = input[i - 1];
                var c = input[i];

                var sum = a + b + c;
                if (prevSum != 0 && sum > prevSum)
                {
                    sumIncreasedCount += 1;
                }
                prevSum = sum;
            }

            Console.WriteLine($"part 2 sum increased count: {sumIncreasedCount}");
        }
    }
}
