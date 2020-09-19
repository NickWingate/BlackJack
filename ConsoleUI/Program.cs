using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

// Following these rules: https://bicyclecards.com/how-to-play/blackjack/

namespace ConsoleUI
{
    class Program
    {
        // Main
        static void Main()
        {
            (Deck deck, List<IPlayers> Players) = InitGame();
            for (int i = 0; i < 2; i++)
            {
                StartGame(Players, deck);
                while (Players[1].Playing)
                {
                    Console.WriteLine($"Hand Value: {Players[1].HandValue}");
                    NextAction(Players[1], deck);
                    if (Players[1].Bust)
                    {
                        Console.WriteLine($"{Players[1]} is bust!");
                    }
                    PrintBanner();
                }
                if (Players[1].Blackjack)
                {
                    Console.WriteLine($"Blackjack!!\n{Players[1]} wins!");
                }
                else
                {
                    ((Dealer)Players[0]).DealerPlay(deck);
                    IPlayers winner = FindWinner(Players);
                    if (winner != null)
                    {
                        Console.WriteLine($"The winner is: {winner}");
                    }
                    else
                    {
                        Console.WriteLine("Tie");
                    }
                }
                foreach (IPlayers player in Players)
                {
                    player.ResetHand();
                }
                switch (PlayAgain())
                {
                    case true:
                        break;
                    case false:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
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
            Players.Add(new User());

            return (deck, Players);
        }
        static void StartGame(List<IPlayers> Players, Deck deck)
        {
            Players[0].DrawCard(deck, 2);
            Players[1].DrawCard(deck, 2);

            PrintBanner();

            Console.WriteLine($"{Players[0]}'s face up card is {((Dealer)Players[0]).FaceUpCard}");
            Console.WriteLine($"{Players[1]} drew:");

            Players[1].ViewCards();
            PrintBanner();
        }
        static bool? PlayAgain()
        {
            Console.WriteLine("Play Again?(y/n)");
            string response = Console.ReadLine().ToLower();
            switch (response)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.WriteLine("Invalid answer");
                    return null;
            }
        }
        static Card NextAction(IPlayers p, Deck d)
        {
            PrintBanner("Action");
            Console.Write("(Hit), (Stand), or (View) Cards?: ");
            string choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "hit":
                    Card drawnCard = p.DrawCard(d);
                    Console.WriteLine($"{p} drew a {drawnCard}");
                    return drawnCard;
                case "stand":
                    p.Stand();
                    return null;
                case "view":
                    p.ViewCards();
                    return null;
                default:
                    Console.WriteLine("Invalid choice");
                    return null;
            }
        }

        static IPlayers FindWinner(List<IPlayers> players)
        {
            if (CheckForTie(players))
            {
                return null;
            }
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
        static bool CheckForTie(List<IPlayers> players)
        {
            switch (players[0].HandValue == players[1].HandValue)
            {
                case true:
                    return true;
                case false:
                    return false;
            }
        }
    }
}
