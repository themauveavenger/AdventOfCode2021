using System;
using System.Collections.Generic;
using AdventOfCode2021.Days;
using AdventOfCode2021.Days.DayTwo;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDay> days = new List<IDay>() { new Day1(), new Day2() };
            foreach (IDay day in days)
            {
                var dayName = day.GetType().Name;
                Console.WriteLine($"**************{dayName}**************");
                day.Run();
                day.RunPart2();
                Console.WriteLine($"**************End {dayName}**************");
            }
        }
    }
}
