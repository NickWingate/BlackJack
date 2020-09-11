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

            Console.Write("Welcome to blackjack\nPlease enter your name: ");
            string userName = Console.ReadLine();
            Player p1 = new Player(userName);

            p1.DrawCards(d1);
            p1.ViewCards();
        }

        static void HitOrStand()
        {
            Console.WriteLine("Hit or Stand?");
            string userResponse = Console.ReadLine();
            if (userResponse == "Hit")
            {

            }
        }
    }
}
