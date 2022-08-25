using System;
using System.Collections.Generic;

namespace Cards
{
    public class Card
    {
        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;


        }
        private string face;
        private string suit;
        private List<string> validFaces => new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private List<string> validSuits => new List<string> { "S", "H", "D", "C" };
        private Dictionary<string, char> suitsConverter => new Dictionary<string, char>()
        {
            {"S",'\u2660' } ,
            {"H",'\u2665' } ,
            {"D",'\u2666' } ,
            {"C",'\u2663' } ,


        };
        public string Face
        {
            get
            {
                return face;


            }
            set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");

                }
                else
                {
                    face = value;


                }


            }


        }
        public string Suit
        {
            get
            {
                return suit;


            }
            set
            {
                if (!validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");

                }
                else
                {
                    suit = value;


                }


            }


        }
        public override string ToString()
        {
            return $"[{face}{suitsConverter[suit]}]";
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            foreach (string card in cardsInfo)
            {
                string[] cardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = cardInfo[0];
                string suit = cardInfo[1];
                Card createdCard = CreateCard(face, suit);
                if (createdCard != null)
                {
                    cards.Add(createdCard);

                }


            }
            foreach (Card card in cards)
            {
                Console.Write(card.ToString() + " ");
                

            }
            Console.WriteLine();
        }
        public static Card CreateCard(string face, string suit)
        {
            try
            {
                Card card = new Card(face, suit);
                return card;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }


        }
    }
}
