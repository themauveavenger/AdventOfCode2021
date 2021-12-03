namespace AdventOfCode2021.Days.DayTwo
{
    public class SubmarinePart2 : ISubmarine
    {
        public int Depth { get; set; }
        public int HorizontalPos { get; set; }
        public int Aim { get; set; }
        public SubmarinePart2()
        {
            HorizontalPos = 0;
            Depth = 0;
            Aim = 0;
        }

        public void Up(int amount)
        {
            Aim -= amount;
        }

        public void Down(int amount)
        {
            Aim += amount;
        }

        public void Forward(int amount)
        {
            HorizontalPos += amount;
            Depth += (Aim * amount);
        }
    }

}
