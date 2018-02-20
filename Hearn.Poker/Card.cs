using System;

namespace Hearn.Poker
{
    public class Card
    {

        public enum Values
        {
            AceLow = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King, 
            Ace
        }

        public enum Suits
        {
            Spades,
            Clubs,
            Hearts,
            Diamonds
        }

        public Values Value { get; set; }

        public Suits Suit { get; set; }

        public override string ToString()
        {
            return $"{Value.ToString()} {Suit.ToString()}";
        }

    }
}
