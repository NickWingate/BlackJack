using BlackJack;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Player
    {
        // Properties
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        // Constructors
        public Player(string name)
        {
            Name = name;
        }

        // Methods
        public void DrawCards(Deck deck)
        {
            Hand.Add(deck.DrawCard());
            Hand.Add(deck.DrawCard());
        }
        public void ViewCards()
        {
            foreach (Card c in Hand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void Hit()
        {

        }

        public void Stand()
        {

        }

    }
}
