using System;
using System.Collections.Generic;

namespace Hearn.Poker.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Hearts}
            };

            //cards.Sort(new CardValueComparer());

            //var handValidator = new HandValidator();
            //var test = handValidator.IsFullHouse(cards);

        }
    }
}
