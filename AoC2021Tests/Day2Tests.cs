using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Days.DayTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021Tests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2_Run_Test_1()
        {
            var d2 = new Day2();
            ISubmarine sub = new SubmarinePart2();
            var instructions = new(string, int)[] { ("forward", 5), ("down", 5), ("forward", 8), ("up", 3), ("down", 8), ("forward", 2) };
            var result = d2.GetProduct(ref sub, instructions);
            Assert.AreEqual(15, sub.HorizontalPos);
            Assert.AreEqual(60, sub.Depth);
            Assert.AreEqual(900, result);
        }
    }
}
