// Auto Yahtzee
// Juha Suvanto
// jsuvanto@iki.fi

// My first C# program.

using System;

namespace AutoYahtzee
{
    class Program
    {        

        static void Main(string[] args)
        {
            Console.WriteLine("============\nAuto Yahtzee\n============");
            Console.WriteLine("This program will start throwing five pieces of six-sided dice until it throws five equal numbers.");
            Console.Write("Enter a seed value to begin or [ENTER] to quit: ");

            while (GetSeed(out int seed))
            {
                Yahtzee yahtzee = new Yahtzee(seed);

                while (!yahtzee.IsYahtzee())
                {
                    yahtzee.Throw();
                }

                Console.WriteLine("Yahtzee! after " + yahtzee.GetThrowcount() + " throws. Used seed: " + seed);
                Console.Write("Enter a new seed or [ENTER] to quit: ");
            }
        }

        static bool GetSeed(out int seed)
        {
            seed = 0;
            while (true) {
                string input = Console.ReadLine();
                if (input == "") return false;                
                else if (Int32.TryParse(input, out seed))
                {
                    Console.WriteLine("Seed: " + seed);
                    return true;
                }
                else Console.Write("Please enter a number between " + Int32.MinValue + " and " + Int32.MaxValue + ": ");                
            }            
        }
    }

    class Yahtzee
    {
        private int[] dice_;
        private const int num_dice_ = 5;
        private int throwcount_ = 0;
        private Random random;       

        public Yahtzee(int seed)
        {
            dice_ = new int[num_dice_];
            random = new Random(seed);
            Throw();
        }

        public void Throw()
        {
            for (int die = 0; die < num_dice_; ++die)
            {
                dice_[die] = random.Next(1, 7);
                Console.Write(dice_[die] + " ");                                
            }            
            Console.WriteLine();
            ++throwcount_;
        }        

        public bool IsYahtzee()
        {
            if (dice_[0] == dice_[1] && dice_[0] == dice_[2] && dice_[0] == dice_[3] && dice_[0] == dice_[4]) return true;
            else return false;
        }

        public int GetThrowcount()
        {
            return throwcount_;
        }
    }
}
