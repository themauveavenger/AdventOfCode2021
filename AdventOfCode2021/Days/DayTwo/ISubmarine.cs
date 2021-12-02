using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Days.DayTwo
{
    public interface ISubmarine
    {
        public int Depth { get; set; }
        public int HorizontalPos { get; set; }

        public void Up(int amount);
        public void Down(int amount);
        public void Forward(int amount);
    }
}
