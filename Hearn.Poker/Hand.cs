using System;
using System.Collections.Generic;
using System.Text;

namespace Hearn.Poker
{
    public class Hand
    {

        public Hand()
        {
            RankedCards = new List<Card>();
            SideCards = new List<Card>();
        }

        public enum HandRanks
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfaKind,
            Straight,
            Flush,
            FullHouse,
            FourOfaKind,
            StraightFlush,
            RoyalFlush
        }

        public HandRanks HandRank { get; set; }

        public List<Card> RankedCards { get; set; }

        public List<Card> SideCards { get; set; }

        public int Score { get; set; }

    }
}
