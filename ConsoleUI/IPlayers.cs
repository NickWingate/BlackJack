using System.Collections.Generic;

namespace ConsoleUI
{
    public interface IPlayers
    {
        bool Bust { get; set; }
        List<Card> Hand { get; set; }
        int HandValue { get; set; }
        Card LastDrawnCard { get; set; }
        string Name { get; set; }
        bool Playing { get; set; }
        bool Blackjack { get; set; }

        Card DrawCard(Deck deck, int amount = 1);
        void Stand();
        void ViewCards();
        void ResetHand();
    }
}