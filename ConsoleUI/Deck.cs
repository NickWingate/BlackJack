using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleUI
{
    public class Deck
    {
        // Fields
        Random rand = new Random();

        // Properties
        public List<Card> Cards { get; set; } = new List<Card>();

        // Constructors
        public Deck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                int staticTestingValue = 1;
                for (int v = 1; v < 14; v++)
                {
                    Cards.Add(new Card(s, v.ToString()));
                }
            }           
        }

        // Methods
        /// <summary>
        /// Writes deck, in order of first card to last card, to console
        /// </summary>
        public void ShowDeck()
        {
            foreach (Card c in Cards)
            {
                Console.WriteLine(c.ToString());
            }
        }

        /// <summary>
        /// Shuffles deck using Fisher Yates Shuffle algorithm
        /// </summary>
        public void ShuffleDeck()
        {
            for (int n = Cards.Count -1; n > 0; n--)
            {
                int r = rand.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[r];
                Cards[r] = temp;
            }
        }
        public Card DrawCard()
        {
            if (Cards.Count > 0)
            {
                Card tempCard = Cards[0];
                Cards.RemoveAt(0);
                return tempCard;
            }
            else
            {
                throw new IndexOutOfRangeException("Deck is empty");
            }
        }
    }
}
