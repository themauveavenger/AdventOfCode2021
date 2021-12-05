using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.DayFour
{
    public class Day4 : IDay
    {
        string inputPath = @".\Days\DayFour\input.txt";
        internal class Space
        {
            public bool Marked { get; set; }
            public int Value { get; set; }
            public Space(int value)
            {
                Value = value;
                Marked = false;
            }
        }

        internal class BingoBoard
        {
            public int BoardNumber { get; set; }
            public List<Space> Spaces { get; set; }
            public bool HasWon { get; set; }

            public int WinCount { get; set; }

            public BingoBoard(List<int[]> numbers)
            {
                HasWon = false; 
                Spaces = new List<Space>();
                foreach (var line in numbers)
                {
                    foreach (var value in line)
                    {
                        Spaces.Add(new Space(value));
                    }
                }
            }

            public void SetMarked(int value)
            {
                var space = Spaces.Find(s => s.Value == value);
                if (space != null)
                {
                    space.Marked = true;
                }
            }
            /*
             * 0  1  2  3  4
             * 5  6  7  8  9
             * 10 11 12 13 14
             * 15 16 17 18 19
             * 20 21 22 23 24
             */
            public bool IsWon(int winCount)
            {
                if (HasWon == true)
                {
                    return HasWon;
                }
                
                // check rows 
                for (var i = 0; i < 25; i += 5)
                {
                    if (Spaces.Take(new Range(i, i + 5)).Where(s => s.Marked == true).Count() == 5)
                    {
                        HasWon = true;
                        WinCount = winCount;
                        return true;
                    }
                }

                // checck columns
                for (int column = 0; column < 5; column++)
                {
                    if (Spaces.Where((s, idx) => idx % 5 == column).Where(s => s.Marked == true).Count() == 5)
                    {
                        HasWon = true;
                        WinCount = winCount;
                        return true;
                    }
                }

                return false;
            }

            public int SumUnmarked()
            {
                return Spaces.Where(s => s.Marked == false).Sum(s => s.Value);
            }

            public int FinalScore(int instructionNum)
            {
                return SumUnmarked() * instructionNum;
            }
        }
        // (List<int> instructions, List<BingoBoard> board)
        internal (List<BingoBoard>, List<int>) ReadInput()
        {
            var input = Helpers.ReadFileLines(inputPath);

            // parse the first line 
            var instructions = input.FirstOrDefault().Split(",").Select(i => Convert.ToInt32(i)).ToList();

            var boards = input.Skip(2) // remove the first two lines
                              .Where(i => string.IsNullOrWhiteSpace(i) == false); // remove the new lines

            // parse each bingo board
            var count = boards.Count();
            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            for (int i = 0; i < count; i += 5)
            {
                var boardNums = boards.Take(new Range(i, i + 5)).Select(i => i.Split(" ").Where(i => string.IsNullOrWhiteSpace(i) == false).Select(i => Convert.ToInt32(i)).ToArray()).ToList();
                bingoBoards.Add(new BingoBoard(boardNums));
            }

            return (bingoBoards, instructions);

        }
        public void Run()
        {
            var (bingoBoards, instructions) = ReadInput();

            foreach (var inst in instructions)
            {
                for (var i = 0; i < bingoBoards.Count(); i += 1)
                {
                    bingoBoards[i].SetMarked(inst);
                    if (bingoBoards[i].IsWon(i))
                    {
                        var result = bingoBoards[i].FinalScore(inst);

                        Console.WriteLine($"part 1: {result}");
                        return;
                    }
                }
            }
        }

        public void RunPart2()
        {
            var (bingoBoards, instructions) = ReadInput();
            var bboardCount = bingoBoards.Count();
            Nullable<int> lastWinner = null;
            foreach (var inst in instructions)
            {
                for (var i = 0; i < bboardCount; i += 1)
                {
                    bingoBoards[i].SetMarked(inst);
                    if (bingoBoards[i].IsWon(i))
                    {
                        lastWinner = i;
                        if (lastWinner != null && bingoBoards.Count(b => b.HasWon == true) == bboardCount)
                        {
                            var result = bingoBoards[i].FinalScore(inst);
                            Console.WriteLine($"part 2: {result}");
                            return;
                        }
                    } 
                }
            }
        }
    }
}
