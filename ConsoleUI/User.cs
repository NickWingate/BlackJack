using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class User : IPlayers
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
                if (Hand.Any(c => c.StringValue == "Ace")
                    && _handValue + 11 <= 21)  // Can I increase the value of an ace from 1 to 10?
                {
                    value += 10;
                }

                if (value > 21)
                {
                    Playing = false;
                    Bust = true;
                }
                _handValue = value;
            }
        }
        public Card LastDrawnCard { get; set; }
        // Constructors
        public User(string name)
        {
            Name = name;
        }
        public User(Deck deck)
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
            //DrawCards(deck);  // commented for testing purposes

            DrawCard(new Card(Suit.Hearts, "10"));
            DrawCard(new Card(Suit.Hearts, "1"));
        }

        // Methods
        public void DrawCards(Deck deck)
        {
            DrawCard(deck);
            DrawCard(deck);
        }
        public void DrawCard(Card c)
        {
            HandValue += c.IntValue;
            Hand.Add(c);
        }
        public Card DrawCard(Deck deck)
        {
            Card card = deck.DrawCard();
            HandValue += card.IntValue;
            Hand.Add(card);
            LastDrawnCard = card;
            return card;
        }
        public void ViewCards()
        {
            foreach (Card c in Hand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void Stand()
        {
            Playing = false;
        }

    }
}
