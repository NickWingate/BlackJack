using BlackJackLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Suit: ");
                string userSuit = Console.ReadLine();
                Console.WriteLine("Value: ");
                string userValue = Console.ReadLine();

                Card test = new Card(userSuit, userValue);
                Console.WriteLine(test.ToString());
            }            
        }
    }
}
