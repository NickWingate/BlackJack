using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackLibrary
{
    class Card
    {
        // Fields
        private string _value;
        private string _suit;
        private readonly string[] possibleSuits = { "Spades", "Hearts", "Diamonds", "Clubs" };

        // Properties
        public string Suit
        {
            get { return _suit;  }
            set 
            {
                if (!possibleSuits.Contains(value))
                {
                    throw new System.ArgumentException("Invalid Suit");
                }
                else
                {
                    _suit = value;
                }
            }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                switch (value)
                {
                    case "1":
                        _value = "Ace";
                        break;
                    case "11":
                        _value = "Jack";
                        break;
                    case "12":
                        _value = "Queen";
                        break;
                    case "13":
                        _value = "King";
                        break;
                    default:
                        _value = value;
                        break;
                }
            }
        }

        public Card(string suit, string value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value} of {this.Suit}";
        }
    }
}
