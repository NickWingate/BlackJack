using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Card
    {
        // Fields
        private string _stringValue;
        private int _intValue;
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
        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                switch (value)
                {
                    case "1":
                        _stringValue = "Ace";
                        _intValue = 11;
                        break;
                    case "11":
                        _stringValue = "Jack";
                        _intValue = 10;
                        break;
                    case "12":
                        _stringValue = "Queen";
                        _intValue = 10;
                        break;
                    case "13":
                        _stringValue = "King";
                        _intValue = 10;
                        break;
                    default:
                        _stringValue = value;
                        _intValue = Convert.ToInt32(value);
                        break;
                }
            }
        }
        public int IntValue { get { return _intValue; } }

        // Constructors
        public Card(string suit, string value)
        {
            this.Suit = suit;
            this.StringValue = value;
        }

        // Methods
        /// <summary>
        /// Returns a string of the card
        /// </summary>
        public override string ToString()
        {
            return $"{this.StringValue} of {this.Suit}";
        }
    }
}
