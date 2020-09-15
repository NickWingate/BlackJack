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
            DrawCards(deck);
            FaceUpCard = Hand[0];
        }

        public void DealerPlay(Deck deck)
        {
            RevealFaceDownCard();
            while (HandValue < 17)
            {
                DrawCard(deck);
                Console.WriteLine($"{Name} hit, they drew {LastDrawnCard}");
            }

            Stand();
            Console.WriteLine($"{Name} is standing with {Hand.Count} cards");
            Console.WriteLine($"{Name}'s final cards are:");
            ViewCards();
            Console.WriteLine($"With a value of: {HandValue}");
        }
        private void RevealFaceDownCard()
        {
            Console.WriteLine($"{Name}'s face down card was: {Hand[1]}");
        }
    }
}
