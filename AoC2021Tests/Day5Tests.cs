using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Days.DayFive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AoC2021Tests
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void GenerateLineTest_1()
        {
            var d = new Day5();
            var result = d.GenerateLine(1, 1, 1, 3);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GenerateLineTest_2()
        {
            var d = new Day5();
            var result = d.GenerateLine(9, 7, 7, 7);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GenerateDiagLine_Test_1()
        {
            var d = new Day5();
            var result = d.GenerateLine(1, 1, 3, 3);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GenerateDiagLine_Test_2()
        {
            var d = new Day5();
            var result = d.GenerateLine(9, 7, 7, 9);
            Assert.AreEqual(3, result.Count());
            var expectedPoints = new List<Point>() { new Point(9, 7), new Point(8, 8), new Point(7, 9) };
            CollectionAssert.AreEquivalent(expectedPoints, result);
        }

        // 8,0 -> 0,8
        [TestMethod]
        public void GenerateDiagLine_Test3()
        {
            var d = new Day5();
            var result = d.GenerateLine(8, 0, 0, 8);
            Assert.AreEqual(9, result.Count());
        }

        [TestMethod]
        public void Test_1()
        {
            var path = @".\Days\DayFive\testInput.txt";
            var d = new Day5();
            var input = d.ParseInput(path);
            var result = d.IntersectionPointCount(input);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Test_2()
        {
            var path = @".\Days\DayFive\testInput_2.txt";
            var d = new Day5();
            var input = d.ParseInput(path);
            var result = d.IntersectionPointCount(input);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_Part_2()
        {
            var path = @".\Days\DayFive\testInput.txt";
            var d = new Day5();
            var input = d.ParseInput_Part2(path);
            var result = d.IntersectionPointCount(input);
            Assert.AreEqual(12, result);
        }
    }
}
