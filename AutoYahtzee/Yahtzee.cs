using System;


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

