using BlackJack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;

// Following these rules: https://bicyclecards.com/how-to-play/blackjack/

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to blackjack!");
            Deck d1 = new Deck();
            d1.ShuffleDeck();

            Player p1 = new Player(d1);
            p1.ViewCards();

            Dealer dealer = new Dealer("Keith", d1);
            while (p1.Playing)
            {
                Console.WriteLine($"Hand Value: {p1.HandValue}");
                NextAction(p1, d1);
            }

            if (p1.Bust)
            {
                Console.WriteLine($"{dealer.Name} Wins!");
                Environment.Exit(0);
            }

            dealer.DealerPlay(d1);
            if (dealer.Bust)
            {
                Console.WriteLine($"{p1.Name} Wins!");
                Environment.Exit(0);
            }

            string winner = FindWinner(p1, dealer);
            if (winner != "Tie")
            {
                Console.WriteLine($"{winner} Wins!");
                Environment.Exit(0);
            }
            Console.WriteLine("Tie");
            
        }

        static void NextAction(Player p, Deck d)
        {
            Console.Write("(Hit), (Stand), or (View) Cards?: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hit":
                    p.DrawCard(d);
                    break;
                case "stand":
                    p.Stand();
                    return;
                case "view":
                    p.ViewCards();
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        static string FindWinner(Player player, Dealer dealer)
        {
            if (player.HandValue > dealer.HandValue)
            {
                return player.Name;
            }
            else if (dealer.HandValue > player.HandValue)
            {
                return dealer.Name;
            }
            else
            {
                return "Tie";
            }
        }
    }
}
