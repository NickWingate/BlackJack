namespace ConsoleUI
{
    public class Card
    {
        // Properties
        public Suit Suit { get; set; }

        public CardValue Value { get; set; }

        // Constructors
        public Card(Suit suit, CardValue value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        // Methods
        /// <summary>
        /// Returns a string of the card
        /// </summary>
        public override string ToString()
        {
            return $"{this.Value} of {this.Suit}";
        }
    }
}