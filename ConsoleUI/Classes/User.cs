using System;
using System.Collections.Generic;

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
                if (value > 21)
                {
                    Bust = true;
                    Playing = false;
                }
                else if (value == 21)
                {
                    Blackjack = true;
                    Playing = false;
                }
                _handValue = value;
            }
        }
        public Card LastDrawnCard { get; set; }
        public bool Blackjack { get; set; }

        // Constructors
        public User(string name)
        {
            Name = name;
        }
        public User()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();

            //DrawCard(new Card(Suit.Hearts, CardValue.Ten));  // Don't Cheat!
            //DrawCard(new Card(Suit.Hearts, CardValue.Ace));
        }

        // Methods
        public override string ToString()
        {
            return this.Name;
        }
        // This method is for testing purposes
        public void DrawCard(Card c)
        {
            HandValue += DetermineCardValue(c);
            Hand.Add(c);
        }
        public Card DrawCard(Deck deck, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Card card = deck.DrawCard();
                HandValue += DetermineCardValue(card);
                Hand.Add(card);
                LastDrawnCard = card;
            }
            return LastDrawnCard;
        }
        public void ViewCards()
        {
            foreach (Card c in Hand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public int DetermineCardValue(Card c)
        {
            if (c.Value != CardValue.Ace)
            {
                return (int) c.Value;
            }
            else
            {
                if (HandValue + (int) c.Value > 21)
                {
                    return 1;
                }
                else
                {
                    return 11;
                }
            }
        }
        public void Stand()
        {
            Playing = false;
        }
        public void ResetHand()
        {
            Playing = true;
            Bust = false;
            Blackjack = false;
            Hand.Clear();
            HandValue = 0;
            LastDrawnCard = null;
        }
    }
}
