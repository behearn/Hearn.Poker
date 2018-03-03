using System;
using System.Collections.Generic;

namespace Hearn.Poker.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            var player1 = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Hearts}
            };

            var player2 = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Spades}
            };


            var handValidator = new HandValidator();

            var player1Hand = handValidator.CheckHand(player1);
            var player2Hand = handValidator.CheckHand(player2);

            if (player1Hand.Score > player2Hand.Score)
            {
                Console.WriteLine("Player 1 wins");
            }
            else if (player2Hand.Score > player1Hand.Score)
            {
                Console.WriteLine("Player 2 wins");
            }
            else
            {
                Console.WriteLine("Draw");
            }

            Console.ReadKey();

            //cards.Sort(new CardValueComparer());

            //var handValidator = new HandValidator();
            //var test = handValidator.IsFullHouse(cards);

        }
    }
}
