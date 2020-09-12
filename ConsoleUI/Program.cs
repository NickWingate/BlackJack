using BlackJack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            p1.ViewCards();

            while (!p1.Bust && p1.Playing)
            {
                //p1.ViewCards();
                Console.WriteLine($"Hand Value: {p1.HandValue}");
                HitOrStand(p1, d1);

            }
            p1.ViewCards();
            Console.WriteLine($"{p1.Name}'s Final Hand Value: {p1.HandValue}");


            Console.WriteLine("End of game");
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
            Console.Write("(Hit), (Stand), or (View) Cards?: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hit":
                    p.Hit(d);
                    break;
                case "stand":
                    p.Stand();  // not yet coded
                    return;
                case "view":
                    p.ViewCards();
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static Player FindWinner(List<Player> players)
        {
            return players.Max();
        }
    }
}
