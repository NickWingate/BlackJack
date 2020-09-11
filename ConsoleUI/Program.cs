using BlackJack;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d1 = new Deck();
            d1.ShowDeck();
            Console.WriteLine("\nShuffled:\n\n");
            d1.ShuffleDeck();
            d1.ShowDeck();
        }
    }
}
