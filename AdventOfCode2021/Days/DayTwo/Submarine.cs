namespace AdventOfCode2021.Days.DayTwo
{
    public class Submarine : ISubmarine
    {
        public int Depth { get; set; }
        public int HorizontalPos { get; set; }

        public Submarine()
        {
            Depth = 0;
            HorizontalPos = 0;
        }

        // decreases depth
        public void Up(int amount)
        {
            Depth -= amount;
        }

        // increases depth
        public void Down(int amount)
        {
            Depth += amount;
        }

        public void Forward(int amount)
        {
            HorizontalPos += amount;
        }
    }

}
