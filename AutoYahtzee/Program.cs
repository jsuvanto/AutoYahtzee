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
                Yahtzee.Yahtzee yahtzee = new Yahtzee.Yahtzee(seed);

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
                else Console.Write("Please enter a number between " + Int32.MinValue + " and " + Int32.MaxValue + " or [ENTER] to quit: ");                
            }            
        }
    }    
}
