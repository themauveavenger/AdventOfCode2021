using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace AdventOfCode2021.Days.DayFive
{
    public class Day5 : IDay
    {
        string inputPath = @".\Days\DayFive\input.txt";

        public void GenLines(int x1, int y1, int x2, int y2)
        {
            Vector2 v1 = new Vector2(x1, y1);
            Vector2 v2 = new Vector2(x2, y2);

            var l = Vector2.Lerp(v1, v2, 1);
            Console.WriteLine(l); 

            var d = Vector2.Distance(v1, v2);
            Console.WriteLine(d);
        }

        public List<Point> GenerateLine(int x1, int y1, int x2, int y2)
        {
            var distanceX = x2 - x1;
            var distanceY = y2 - y1;
            var stepX = Math.Sign(distanceX);
            var stepY = Math.Sign(distanceY);
            var len = Math.Max(Math.Abs(distanceX), Math.Abs(distanceY)) + 1;

            return Enumerable.Range(0, len).Select(i => new Point(x1 + (stepX * i), y1 + (stepY * i))).ToList();
        }
        
        public List<List<Point>> ParseInput(string alternatePath = "")
        {
            string path = null; 
            if (!string.IsNullOrWhiteSpace(alternatePath))
            {
                path = alternatePath;
            } else
            {
                path = inputPath;
            }
            var lines = Helpers.ReadFileLines(path);

            // 645,570 -> 517,570
            // x1,y1 -> x2,y2
            List<List<Point>> parsedLines = new List<List<Point>>();
            foreach (var line in lines)
            {
                var splLine = line.Split(" -> ");
                var x1y1 = splLine[0];
                var x2y2 = splLine[1];
                var first = x1y1.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
                var second = x2y2.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
                var x1 = first[0];
                var y1 = first[1];
                var x2 = second[0];
                var y2 = second[1];
                if (x1 == x2 || y1 == y2)
                {
                    // only use horizontal or vertical lines
                    var pointsOnLine = GenerateLine(first[0], first[1], second[0], second[1]);
                    parsedLines.Add(pointsOnLine);
                }
            }
            return parsedLines;
        }

        public List<List<Point>> ParseInput_Part2(string alternatePath = "", bool diag = false)
        {
            string path = null;
            if (!string.IsNullOrWhiteSpace(alternatePath))
            {
                path = alternatePath;
            }
            else
            {
                path = inputPath;
            }
            var lines = Helpers.ReadFileLines(path);

            // 645,570 -> 517,570
            // x1,y1 -> x2,y2
            List<List<Point>> parsedLines = new List<List<Point>>();
            foreach (var line in lines)
            {
                var splLine = line.Split(" -> ");
                var x1y1 = splLine[0];
                var x2y2 = splLine[1];
                var first = x1y1.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
                var second = x2y2.Split(",").Select(a => Convert.ToInt32(a)).ToArray();
                var x1 = first[0];
                var y1 = first[1];
                var x2 = second[0];
                var y2 = second[1];
                var pointsOnLine = GenerateLine(x1, y1, x2, y2);
                if (x1 == x2 || y1 == y2)
                {
                    // only use horizontal or vertical lines
                    parsedLines.Add(pointsOnLine);
                } else if(diag)
                {
                    // diag line!
                    parsedLines.Add(pointsOnLine);
                }
            }
            return parsedLines;
        }

        public int IntersectionPointCount(List<List<Point>> parsedLines)
        {
            var pointSet = new HashSet<Point>();
            for (int i = 0; i < parsedLines.Count; i++)
            {
                var line = parsedLines[i];

                for (int j = i + 1; j < parsedLines.Count; j++)
                {
                    // see if this line interesects with any other line
                    var otherLine = parsedLines[j];
                    var intersection = line.Intersect(otherLine).ToList();

                    foreach(var p in intersection)
                    {
                        pointSet.Add(p);
                    }
                }
            }
            return pointSet.Count();
        }

        public void Run()
        {
            var parsedLines = ParseInput();

            var pointCount = IntersectionPointCount(parsedLines);

            Console.WriteLine($"part 1: {pointCount}");
        }

        public void RunPart2()
        {
            var parsedLines = ParseInput_Part2();

            var pointCount = IntersectionPointCount(parsedLines);

            // 19338 too high? 
            // 15188 too low? 
            Console.WriteLine($"part 2: {pointCount}");
        }
    }
}
