using BlackJack;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Player
    {
        // Fields
        private int _handValue = 0;

        // Properties
        public bool Playing { get; set; } = true;
        public bool Bust { get; set; } = false;
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public int HandValue
        {
            get { return _handValue; }
            set
            {
                if (value > 21)
                {
                    Playing = false;
                    Bust = true;
                    Console.WriteLine($"Bust! {Name} loses");
                }
                _handValue = value;
            }
        }
        public Card LastDrawnCard { get; set; }
        // Constructors
        public Player(string name)
        {
            Name = name;
        }
        public Player(Deck deck)
        {
            Console.Write("Welcome to blackjack\nPlease enter your name: ");
            Name = Console.ReadLine();
            DrawCards(deck);
        }

        // Methods
        public void DrawCards(Deck deck)
        {
            DrawCard(deck);
            DrawCard(deck);
        }
        public void ViewCards()
        {
            foreach (Card c in Hand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void DrawCard(Deck deck)
        {
            Card card = deck.DrawCard();
            HandValue += card.IntValue;
            Hand.Add(card);
            LastDrawnCard = card;
        }

        public void Stand()
        {
            Playing = false;
        }

    }
}
