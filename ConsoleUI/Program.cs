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
            d1.ShuffleDeck();

            Player p1 = InitPlayer(d1);

            while (p1.HandValue != -1)
            {
                p1.ViewCards();
                Console.WriteLine($"Hand Value: {p1.HandValue}");
                HitOrStand(p1, d1);

            }
        }

        /// <summary>
        /// Creates a new Player instance, gets username from user, draws cards.
        /// </summary>
        /// <param name="d">Deck to use</param>
        /// <returns>Player</returns>
        static Player InitPlayer(Deck d)
        {
            Console.Write("Welcome to blackjack\nPlease enter your name: ");
            string userName = Console.ReadLine();
            Player p = new Player(userName);
            p.DrawCards(d);
            return p;
        }

        static void HitOrStand(Player p, Deck d)
        {
            Console.Write("Hit or Stand?: ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "hit")
            {
                p.Hit(d);
            }
            else if (choice == "stand")
            {
                
            }
        }
    }
}
