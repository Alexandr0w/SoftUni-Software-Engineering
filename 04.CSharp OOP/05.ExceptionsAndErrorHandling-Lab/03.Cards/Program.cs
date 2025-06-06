﻿namespace Cards
{
    public class Program
    {
        static void Main()
        {
            List<Card> deck = new List<Card>();

            string[] cardsData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardsData.Length; i++)
            {
                string[] cardData = cardsData[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string face = cardData[0];
                string suit = cardData[1];

                try
                {
                    Card card = Card.CreateCard(face, suit);
                    deck.Add(card); 
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", deck));
        }
    }

    class Card
    {
        private string Face { get; set; }
        private string Suit { get; set; }

        public static Card CreateCard(string face, string suit)
        {
            List<string> validFaces = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            List<string> validSuits = new() { "S", "H", "D", "C" };

            if (!validFaces.Any(f => f == face) || !validSuits.Any(s => s == suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            switch (suit)
            {
                case "S":
                    suit = "\u2660";
                    break;
                case "H":
                    suit = "\u2665";
                    break;
                case "D":
                    suit = "\u2666";
                    break;
                case "C":
                    suit = "\u2663";
                    break;
            }

            return new() { Face = face, Suit = suit };
        }

        public override string ToString() => $"[{this.Face}{this.Suit}]";
    }
}
