using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.DayThree
{
    public class Day3 : IDay
    {
        string inputPath = @".\Days\DayThree\input.txt";

        /// <summary>
        /// gamma = most common bit
        /// epsilon = least common bit
        /// </summary>
        /// <param name="binaryLines"></param>
        /// <param name="binaryLen"></param>
        /// <returns></returns>
        public (string gamma, string epsilon) GetRates(string[] binaryLines, int binaryLen)
        {
            // 0001 1001 0001
            var zeroesCounts = new Dictionary<int, int>();
            for(int i = 0; i < binaryLen; i++)
            {
                zeroesCounts[i] = 0;
            }

            foreach (var line in binaryLines)
            {
                for (var position = 0; position < line.Length; position++)
                {
                    var bit = line[position];
                    if (bit == '0')
                    {
                        zeroesCounts[position]++;
                    }
                }
            }


            var commonFactor = binaryLines.Length / 2;

            var gamma = "";
            var epsilon = "";
            foreach(var zero in zeroesCounts)
            {
                var position = zero.Key;
                var zeroCount = zero.Value;
                if (zeroCount > commonFactor)
                {
                    gamma = gamma + "0";
                    epsilon = epsilon + "1";
                } else
                {
                    gamma = gamma + "1";
                    epsilon = epsilon + "0";
                }
            }

            return (gamma, epsilon);
        }

        public int GetIntegerValue(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public void Run()
        {
            var lines = Helpers.ReadFileLines(inputPath);

            var (gamma, epsilon) = GetRates(lines, 12);
            var gammaInt = GetIntegerValue(gamma);
            var epsilonInt = GetIntegerValue(epsilon);
            var result = gammaInt * epsilonInt;
            Console.WriteLine($"part 1: {result}");
        }

        public int GetOxygenRating(string[] binaryLines, int size)
        {
            for (int i = 0; i < size; i++)
            {
                var (gamma, _) = GetRates(binaryLines, size);

                if (binaryLines.Length == 1)
                {
                    break;
                } else
                {
                    binaryLines = binaryLines.Where(line => gamma[i] == line[i]).ToArray();
                }
            }

            return GetIntegerValue(binaryLines.FirstOrDefault());
        }

        public int GetCO2Rating(string[] binaryLines, int size) 
        {
            for (int i = 0; i < size; i++)
            {
                var (_, epsilon) = GetRates(binaryLines, size);

                if (binaryLines.Length == 1)
                {
                    break;
                }
                else
                {
                    binaryLines = binaryLines.Where(line => epsilon[i] == line[i]).ToArray();
                }
            }

            return GetIntegerValue(binaryLines.FirstOrDefault());
        }

        public void RunPart2()
        {
            var binaryLines = Helpers.ReadFileLines(inputPath);

            var oxygen = GetOxygenRating(binaryLines, 12);

            binaryLines = Helpers.ReadFileLines(inputPath);

            var co2 = GetCO2Rating(binaryLines, 12);

            var result = oxygen * co2;

            Console.WriteLine($"part 2: {result}");
        }
    }
}
