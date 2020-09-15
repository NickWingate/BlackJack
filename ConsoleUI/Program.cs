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
            
            (Deck deck, List<IPlayers> Players) = InitGame();

            
            while (Players[1].Playing)
            {
                Console.WriteLine($"Hand Value: {Players[1].HandValue}");
                NextAction(Players[1], deck);
                PrintBanner();
            }

            if (Players[1].Bust)
            {
                Console.WriteLine($"{Players[1].Name} Bust!");
                Console.WriteLine($"{Players[0].Name} Wins!");
                Environment.Exit(0);
            }

            ((Dealer)Players[0]).DealerPlay(deck);
            if (Players[0].Bust)
            {
                Console.WriteLine($"{Players[1].Name} Wins!");
                Environment.Exit(0);
            }

            // Determine who won
            string winner = FindWinner(Players[1], Players[0]);
            if (winner != "Tie")
            {
                Console.WriteLine($"{winner} Wins!");
                Environment.Exit(0);
            }
            Console.WriteLine("Tie");
            
        }

        static (Deck, List<IPlayers>) InitGame()
        {
            PrintBanner("Start");
            Console.WriteLine("Welcome to blackjack!");
            
            List<IPlayers> Players = new List<IPlayers>();

            Deck deck = new Deck();
            deck.ShuffleDeck();

            Players.Add(new Dealer("Keith", deck));  // Dealer is always [0] player
            Players.Add(new User(deck));

            PrintBanner();
            Console.WriteLine($"{Players[1].Name} drew:");
            Players[1].ViewCards();
            PrintBanner();

            return (deck, Players);
        }

        static void NextAction(IPlayers p, Deck d)
        {
            Console.Write("(Hit), (Stand), or (View) Cards?: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hit":
                    Card drawnCard = p.DrawCard(d);
                    Console.WriteLine($"{p.Name} drew a {drawnCard.StringValue}");
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

        static string FindWinner(IPlayers player, IPlayers dealer)
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
        
        static void PrintBanner(string title = "")
        {
            int buffer = title.Length/2;
            Console.Write(string.Join("", Enumerable.Repeat("-", 25 - buffer)));
            Console.Write(title.ToUpper());
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 25 - buffer)));
        }
    }
}
