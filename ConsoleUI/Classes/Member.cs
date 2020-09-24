using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public abstract class Member
    {
        private int _handValue = 0;

        // Blackjack, Bust, and Playing are all similar properties...
        public bool Blackjack { get; protected set; } = false;

        public bool Bust { get; protected set; } = false;
        public List<Card> Hand { get; protected set; } = new List<Card>();

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
                else
                {
                    _handValue = value;
                }
            }
        }

        public Card LastDrawnCard { get; protected set; }
        public string Name { get; set; }
        public bool Playing { get; set; } = false;  // maybe private set
        public int Score { get; set; } = 0; // maybe private set

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

        public void ResetHand()
        {
            Playing = true;
            Bust = false;
            Blackjack = false;
            Hand.Clear();
            HandValue = 0;
            LastDrawnCard = null;
        }

        public void ConsoleWriteCards()
        {
            foreach (Card card in Hand)
            {
                Console.WriteLine(card);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private int DetermineCardValue(Card card)
        {
            if (card.Value != CardValue.Ace)
            {
                return (int)card.Value;
            }
            else
            {
                if (HandValue + (int)card.Value > 21)
                {
                    return 1;
                }
                else
                {
                    return 11;
                }
            }
        }
    }
}