namespace AdventOfCode2021.Days.DayTwentyOne
{
    public class Player
    {
        private readonly int _maxSpace = 10;
        public int CurrentSpace { get; set; }
        public int Score { get; set; }
        public Player(int startingSpace)
        {
            CurrentSpace = startingSpace;
            Score = 0;
        }

        public void IncreaseScore()
        {
            Score += CurrentSpace;
        }

        /// <summary>
        /// gets the roll amount
        /// </summary>
        /// <param name="die"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public int Roll(ref IDie die, int times)
        {
            int sum = 0;
            for (int i = 0; i < times; i++)
            {
                sum += die.Roll();
            }
            return sum;
        }

        /// <summary>
        /// moves the indicated numbers of spaces
        /// </summary>
        /// <param name="spaces"></param>
        /// 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        public void Move(int spaces)
        {
            for (int i = 0; i < spaces; i += 1)
            {
                CurrentSpace += 1;
                if (CurrentSpace > _maxSpace)
                {
                    // wrap around back to 1
                    CurrentSpace = 1;
                }
            }
            IncreaseScore();
        }
    }

    public interface IDie
    {
        public int Roll();
    }

    public class DeterministicDie : IDie
    {
        public int Sides { get; set; }
        public int CurrentNumber { get; set; }
        public int RollCount { get; set; }
        public DeterministicDie(int sides)
        {
            CurrentNumber = 1;
            Sides = sides;
            RollCount = 0;
        }

        public int Roll()
        {
            int returnVal = CurrentNumber;
            CurrentNumber += 1; 
            if (CurrentNumber > Sides)
            {
                CurrentNumber = 1;
            }
            RollCount += 1;
            return returnVal;
        }
    }

    public class QuantumDie : IDie
    {
        public int Roll()
        {
            return 1;
        }
    }

    /// <summary>
    /// Player 1 starting position: 7
    /// Player 2 starting position: 3
    /// </summary>
    public class Day21 : IDay
    {
        public void Run()
        {
            UInt64 winCount;
            int maxScore = 1000;
            int rollTimes = 3;
            var player1 = new Player(7);
            var player2 = new Player(3);
            var die = new DeterministicDie(100);
            Player winner;
            Player loser;
            do
            {
                var p1Spaces = player1.Roll(ref die, rollTimes);
                player1.Move(p1Spaces);
                // check winner
                if (player1.Score >= maxScore)
                {
                    winner = player1;
                    loser = player2;
                    break; 
                }

                var p2Spaces = player2.Roll(ref die, rollTimes);
                player2.Move(p2Spaces);
                if (player2.Score >= maxScore)
                {
                    winner = player2;
                    loser = player1;
                    break;
                }
            }
            while (true);

            var result = loser.Score * die.RollCount;
            Console.WriteLine($"part 1: {result}");
        }

        public void RunPart2()
        {
            Console.WriteLine("not done yet");
        }
    }
}
