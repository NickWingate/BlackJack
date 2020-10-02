using System;

namespace ConsoleUI
{
    public class Dealer : Member
    {
        public Card FaceUpCard => Hand[0];

        public Dealer(string name)
        {
            this.Name = name;
        }

        public Status DealerPlay(Deck deck)
        {
            Program.PrintBanner("Start of dealer play");
            RevealFaceDownCard();
            while (Status == Status.Playing && HandValue < 17)
            {
                DrawCard(deck);
                Console.WriteLine($"{Name} hit, they drew {LastDrawnCard}");
            }
            return Status;
            //Status = Status.Standing;
            //Program.PrintBanner("End of dealer play");
            //Console.WriteLine($"{Name}'s final cards are:");
            //ConsoleWriteCards();
            //Console.WriteLine($"Adding to a total value of: {HandValue}");
        }

        private void RevealFaceDownCard()
        {
            Console.WriteLine($"{Name}'s face down card was: {Hand[1]}");
        }
    }
}