using System;
using System.Collections.Generic;
using System.Linq;

// Following these rules: https://bicyclecards.com/how-to-play/blackjack/

namespace ConsoleUI
{
    internal class Program
    {
        // Main
        private static void Main()
        {
            (Deck deck, List<Member> players) = InitGame();

            while (true)
            {
                StartRound(players, deck);

                while (players[1].Status == Status.Playing)
                {
                    Console.WriteLine($"Hand Value: {players[1].HandValue}");
                    NextAction(players[1], deck);
                }
                switch (players[1].Status)
                {
                    case Status.Bust:
                        Console.WriteLine($"{players[1]} is bust!");
                        break;
                    case Status.Blackjack:
                        Console.WriteLine($"Blackjack!!\n{players[1]} wins!");
                        break;
                    case Status.Standing:
                        {
                            Status dealerResult = ((Dealer)players[0]).DealerPlay(deck);
                            switch (dealerResult)
                            {
                                case Status.Bust:
                                    Console.WriteLine($"{players[0]} is bust!");
                                    break;
                                case Status.Blackjack:
                                    Console.WriteLine($"Blackjack!!\n{players[0]} wins!");
                                    break;
                                default:
                                    Member winner = FindWinner(players);
                                    switch (winner)
                                    {
                                        case null:
                                            Console.WriteLine("Tie");
                                            break;
                                        default:
                                            Console.WriteLine($"The winner is: {winner}");
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
                AskNewRound(players);
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

        private static (Deck, List<Member>) InitGame()
        {
            PrintBanner("Start");
            Console.WriteLine("Welcome to blackjack!");

            List<Member> Players = new List<Member>();

            Deck deck = new Deck();
            deck.ShuffleDeck();

            Players.Add(new Dealer("Keith"));  // Dealer is always [0] player
            Console.Write("Name: ");
            Players.Add(new User(Console.ReadLine()));

            return (deck, Players);
        }

        private static void StartRound(List<Member> Players, Deck deck)
        {
            Players[0].DrawCard(deck, 2);
            Players[1].DrawCard(deck, 2);

            PrintBanner();

            Console.WriteLine($"{Players[0]}'s face up card is {((Dealer)Players[0]).FaceUpCard}");
            Console.WriteLine($"{Players[1]} drew:");

            Players[1].ConsoleWriteCards();
            PrintBanner();
        }

        private static void AskNewRound(List<Member> players)
        {
            foreach (Member player in players)
            {
                player.ResetHand();
            }
            bool? response = null;  // may be able to make this more efficient
            while (response == null)
            {
                response = PlayAgain();
                switch (response)
                {
                    case true:
                        break;
                    case false:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            //Console.Clear();
        }

        private static bool? PlayAgain()
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

        private static Card NextAction(Member p, Deck d)
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
                    p.ConsoleWriteCards();
                    return null;

                default:
                    Console.WriteLine("Invalid choice");
                    return null;
            }
        }

        private static Member FindWinner(List<Member> players)
        {
            if (CheckForTie(players))
            {
                return null;
            }
            try
            {
                var winner = players
                    .Where(x => x.Status != Status.Bust)
                    .OrderByDescending(x => x.HandValue)
                    .First();

                return winner;
            }
            catch (InvalidOperationException)  // This is when calling .First() doesnt work i.e where both bust
            {
                return players[0];
            }
        }

        private static bool CheckForTie(List<Member> players)
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