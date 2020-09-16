using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Dealer : User
    {
        public Card FaceUpCard { get; set; }
        public Dealer(string name, Deck deck) : base("Dealer " + name) 
        {
            DrawCard(deck);
            DrawCard(deck);
            FaceUpCard = Hand[0];
        }

        public void DealerPlay(Deck deck)
        {
            Program.PrintBanner("Start of dealer play");
            RevealFaceDownCard();
            while (HandValue < 17)
            {
                DrawCard(deck);
                Console.WriteLine($"{Name} hit, they drew {LastDrawnCard}");
            }

            Stand();
            Program.PrintBanner("End of dealer play");
            Console.WriteLine($"{Name}'s final cards are:");
            ViewCards();
            Console.WriteLine($"Adding to a total value of: {HandValue}");
        }
        private void RevealFaceDownCard()
        {
            Console.WriteLine($"{Name}'s face down card was: {Hand[1]}");
        }
    }
}
