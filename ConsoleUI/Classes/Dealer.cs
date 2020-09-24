﻿using System;

namespace ConsoleUI
{
    public class Dealer : Member
    {
        public Card FaceUpCard => Hand[0];

        public Dealer(string name, Deck deck) : base("Dealer " + name)
        { }

        public void DealerPlay(Deck deck)
        {
            Program.PrintBanner("Start of dealer play");
            RevealFaceDownCard();
            while (HandValue < 17)
            {
                DrawCard(deck);
                Console.WriteLine($"{Name} hit, they drew {LastDrawnCard}");
            }

            Playing = false;
            Program.PrintBanner("End of dealer play");
            Console.WriteLine($"{Name}'s final cards are:");
            ConsoleWriteCards();
            Console.WriteLine($"Adding to a total value of: {HandValue}");
        }

        private void RevealFaceDownCard()
        {
            Console.WriteLine($"{Name}'s face down card was: {Hand[1]}");
        }
    }
}