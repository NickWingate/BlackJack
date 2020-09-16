using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Following these rules: https://bicyclecards.com/how-to-play/blackjack/

namespace ConsoleUI
{
    class Program
    {
        // Main
        static void Main(string[] args)
        {
            (Deck deck, List<IPlayers> Players) = InitGame();

            while (Players[1].Playing)
            {
                Console.WriteLine($"Hand Value: {Players[1].HandValue}");
                NextAction(Players[1], deck);
                PrintBanner();
            }

            Console.WriteLine(FindWinner(Players).Name);
            
        }

        // Methods
        
        /// <summary>
        /// Prints a pretty banner with a (nearly) consistant length
        /// </summary>
        /// <param name="title"> Calling without any parameter defaults to a titleless banner</param>
        public static void PrintBanner(string title = "")
        {
            int buffer = title.Length / 2;
            Console.Write(string.Join("", Enumerable.Repeat("-", 25 - buffer)));
            Console.Write(title.ToUpper());
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 25 - buffer)));
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

            Console.WriteLine($"{Players[0].Name}'s face up card is {((Dealer)Players[0]).FaceUpCard}");
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
                    Console.WriteLine($"{p.Name} drew a {drawnCard}");
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

        static IPlayers FindWinner(List<IPlayers> players)
        {
            try
            {
                var winner = players
                .Where(x => !x.Bust)
                .OrderByDescending(x => x.HandValue)
                .First();

                return winner;
            }
            catch (InvalidOperationException)  // This is when calling .First() doesnt work
            {
                return players[0];
            }           
        }
    }
}
