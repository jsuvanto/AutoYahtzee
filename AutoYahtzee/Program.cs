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

            int seed;

            if (GetSeed(out seed))
            {

                while (true)
                {
                    Random random = new Random(seed);
                    int[] dice = new int[5];
                    int throwcount = 0;

                    do
                    {
                        for (int die = 0; die < 5; die++)
                        {
                            dice[die] = random.Next(1, 7);
                            Console.Write(dice[die] + " ");
                            throwcount++;
                        }
                        Console.WriteLine();
                    }
                    while (dice[0] != dice[1] || dice[0] != dice[2] || dice[0] != dice[3] || dice[0] != dice[4]); // I'm sure there's a more elegant way to do this.


                    Console.WriteLine("Yahtzee! after " + throwcount + " throws. Used seed: " + seed);
                    Console.Write("Enter a new seed or [ENTER] to quit: ");

                    if (!GetSeed(out seed)) break;

                }
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
}
