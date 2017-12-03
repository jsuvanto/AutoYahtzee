using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YahtzeeTest
{
    [TestClass]
    public class YahtzeeTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Yahtzee.Yahtzee yahtzee = new Yahtzee.Yahtzee(100);
            int[] dice = yahtzee.GetDice();
            // All dice are 0 when initialized, but the constructor throws once.
            Assert.AreNotEqual(0, dice[0]);
            Assert.AreNotEqual(0, dice[1]);
            Assert.AreNotEqual(0, dice[2]);
            Assert.AreNotEqual(0, dice[3]);
            Assert.AreNotEqual(0, dice[4]);            

            // Constructor throws the dice once.
            Assert.AreEqual(1, yahtzee.GetThrowcount());
        }

        [TestMethod]
        public void TestThrow()
        {
            Yahtzee.Yahtzee yahtzee = new Yahtzee.Yahtzee(100);
            int old_throwcount = yahtzee.GetThrowcount();
            yahtzee.Throw();            
            Assert.AreNotEqual(old_throwcount, yahtzee.GetThrowcount());            
        }

        [TestMethod]
        public void TestIsYahtzee()
        {
            Yahtzee.Yahtzee yahtzee = new Yahtzee.Yahtzee(1472); // Seed 1472 is known to produce a Yahtzee with the first throw.            
            Assert.IsTrue(yahtzee.IsYahtzee());
            yahtzee.Throw(); // Throw again.
            Assert.IsFalse(yahtzee.IsYahtzee()); // It probably won't throw another Yahtzee in a row.
        }

        [TestMethod]
        public void TestGetThrowcount()
        {
            Yahtzee.Yahtzee yahtzee = new Yahtzee.Yahtzee(100); // Constructor throws once.
            // Throw four more times.
            int throwtimes = 4;
            for (int i = 0; i < throwtimes; ++i)
            {
                yahtzee.Throw();             
            }

            // There should be five throws by now.
            Assert.AreEqual(5, yahtzee.GetThrowcount());
        }
    }
}
