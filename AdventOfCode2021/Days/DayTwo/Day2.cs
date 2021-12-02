using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.DayTwo
{
    public partial class Day2 : IDay
    {
        string inputPath = @".\Days\Day2Resources\input.txt";

        public (string, int)[] GetInstructions()
        {
            return Helpers.ReadFileLines(inputPath)
                .Select(i => i.Split(" "))
                .Select(i => (i[0], Convert.ToInt32(i[1])))
                .ToArray();
        }

        public int GetProduct(ref ISubmarine sub, (string, int)[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                var instr = instructions[i];
                switch (instr.Item1)
                {
                    case "forward":
                        sub.Forward(instr.Item2);
                        break;
                    case "up":
                        sub.Up(instr.Item2);
                        break;
                    case "down":
                        sub.Down(instr.Item2);
                        break;
                    default:
                        throw new Exception("invalid instruction");
                }
            }

            return sub.Depth * sub.HorizontalPos;
        }

        public void Run()
        {
            var instructions = GetInstructions();

            ISubmarine sub = new Submarine();
            var result = GetProduct(ref sub, instructions);

            Console.WriteLine($"part 1: {result}");
        }

        public void RunPart2()
        {
            var instructions = GetInstructions();

            ISubmarine sub = new SubmarinePart2();

            var result = GetProduct(ref sub, instructions);

            Console.WriteLine($"part 2: {result}");
        }
    }
}
