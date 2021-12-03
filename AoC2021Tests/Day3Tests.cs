using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Days.DayThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void GetRates_Test_1()
        {
            var d3 = new Day3();
            var input = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var (gamma, epsilon) = d3.GetRates(input, 5);
            Assert.AreEqual("10110", gamma);
            Assert.AreEqual("01001", epsilon);
        }

        [TestMethod]
        public void GetOxygenRating_Test_1()
        {
            var d3 = new Day3();
            var input = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var result = d3.GetOxygenRating(input, 5);
            Assert.AreEqual(23, result);
        }

        [TestMethod]
        public void GetCO2Rating_Test_1()
        {
            var d3 = new Day3();
            var input = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            var result = d3.GetCO2Rating(input, 5);
            Assert.AreEqual(10, result);
        }
    }
}
