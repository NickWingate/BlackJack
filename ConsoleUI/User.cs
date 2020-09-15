using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;

namespace ConsoleUI
{
    public class User : IPlayers
    {
        // Fields
        private int _handValue = 0;
        private List<Card> _hand = new List<Card>();
        
        // Properties
        public bool Playing { get; set; } = true;
        public bool Bust { get; set; } = false;
        public string Name { get; set; }
        public int AceValueBuffer { get; set; }
        public List<Card> Hand
        {
            get { return _hand; }
            set
            {
                AceValueBuffer = 10 * AcesInHand();
            }
        }
        public int HandValue
        {
            get { return _handValue; }
            set
            {
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
            Hand = new List<Card>();
        }
        public User(Deck deck)
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();
            Hand = new List<Card>();
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

        public int AcesInHand()
        {
            int count = 0;
            foreach (Card card in Hand)
            {
                if (card.StringValue == "Ace")
                {
                    count++;
                }
            }
            return count;
        }

    }
}
