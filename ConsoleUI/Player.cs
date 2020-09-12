using BlackJack;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    class Player
    {
        // Fields
        private int _handValue = 0;

        // Properties
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public int HandValue
        {
            get { return _handValue; }
            set
            {
                if (value > 21)
                {
                    _handValue = -1;  // -1 is bust
                }
                else
                {
                    _handValue = value;
                }
            }
        }

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
            HandValue += Hand[0].IntValue + Hand[1].IntValue;
        }
        public void ViewCards()
        {
            foreach (Card c in Hand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void Hit(Deck deck)
        {
            Hand.Add(deck.DrawCard());
        }

        public void Stand()
        {

        }

    }
}
