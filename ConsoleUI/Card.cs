using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    public class Card
    {
        // Fields
        private string _stringValue;

        // Properties
        public Suit Suit { get; set; }
        public int IntValue { get; private set; }
        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                switch (value)
                {
                    case "1":
                        _stringValue = "Ace";
                        IntValue = 1;  // Increase to 11 majority of time in Player.cs
                        break;
                    case "11":
                        _stringValue = "Jack";
                        IntValue = 10;
                        break;
                    case "12":
                        _stringValue = "Queen";
                        IntValue = 10;
                        break;
                    case "13":
                        _stringValue = "King";
                        IntValue = 10;
                        break;
                    default:
                        _stringValue = value;
                        IntValue = Convert.ToInt32(value);
                        break;
                }
            }
        }

        // Constructors
        public Card(Suit suit, string value)
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
