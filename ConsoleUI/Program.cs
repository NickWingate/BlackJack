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
            // Initializing game
            Console.WriteLine("Welcome to blackjack!");
            Deck deck = new Deck();
            deck.ShuffleDeck();

            Player player = new Player(deck);
            player.ViewCards();

            // Game starts
            Dealer dealer = new Dealer("Keith", deck);

            // Player's turn
            while (player.Playing)
            {
                Console.WriteLine($"Hand Value: {player.HandValue}");
                NextAction(player, deck);
            }

            // Determine if player is bust
            if (player.Bust)
            {
                Console.WriteLine($"{dealer.Name} Wins!");
                Environment.Exit(0);
            }

            // Dealer's turn
            dealer.DealerPlay(deck);

            // Determine who won
            string winner = FindWinner(player, dealer);
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
            if (player.HandValue > dealer.HandValue || dealer.Bust)
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
