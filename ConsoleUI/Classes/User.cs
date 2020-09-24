using System;

namespace ConsoleUI
{
    public class User : Member
    {
        // Constructors
        public User(string name)
        {
            Name = name;
        }

        public User()
        {
            Console.Write("Please enter your name: ");
            Name = Console.ReadLine();

            //DrawCard(new Card(Suit.Hearts, CardValue.Ten));  // Don't Cheat!
            //DrawCard(new Card(Suit.Hearts, CardValue.Ace));
        }
    }
}