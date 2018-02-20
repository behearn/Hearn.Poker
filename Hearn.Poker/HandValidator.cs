using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Hearn.Poker
{
    public class HandValidator
    {

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

        public HandRanks CheckHand(List<Card> cards)
        {

            if (cards.Count != 5)
            {
                throw new Exception("Poker hand should contain 5 cards");
            }

            if (cards.Select(c => c.ToString()).Distinct().Count() != 5)
            {
                throw new Exception("Duplicate card detected");
            }

            var tempCards = cards.Select(c => new Card() { Value = c.Value, Suit = c.Suit }).ToList();

            var handRank = HandRanks.HighCard;

            if (IsRoyalFlush(tempCards))
            {
                handRank = HandRanks.RoyalFlush;
            }
            else if (IsStraightFlush(tempCards))
            {
                handRank = HandRanks.StraightFlush;
            }
            else if (IsFourOfaKind(tempCards))
            {
                handRank = HandRanks.FourOfaKind;
            }
            else if (IsFullHouse(tempCards))
            {
                handRank = HandRanks.FullHouse;
            }
            else if (IsFlush(tempCards))
            {
                handRank = HandRanks.Flush;
            }
            else if (IsStraight(tempCards))
            {
                handRank = HandRanks.Straight;
            }
            else if (IsThreeOfaKind(tempCards))
            {
                handRank = HandRanks.ThreeOfaKind;
            }
            else if (IsTwoPair(tempCards))
            {
                handRank = HandRanks.TwoPair;
            }
            else if (IsPair(tempCards))
            {
                handRank = HandRanks.Pair;
            }
            
            return handRank;

        }

        private bool IsPair(List<Card> cards)
        {
            var hasPair = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2).Any();
            return hasPair;
        }

        private bool IsTwoPair(List<Card> cards)
        {
            var pairs = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2);
            if (pairs.Count() == 2)
            {
                return true;
            }
            return false;
        }

        private bool IsThreeOfaKind(List<Card> cards)
        {
            var hasGroupOfThree = cards.GroupBy(c => c.Value).Where(x => x.Count() == 3).Any();
            return hasGroupOfThree;
        }

        private bool IsStraight(List<Card> cards)
        {
            cards.Sort(new CardValueComparer());

            var isStraight = true;

            for (var i = 1; i < cards.Count; i++)
            {
                if (cards[i].Value != cards[i-1].Value + 1)
                {
                    isStraight = false;
                }
            }

            if (!isStraight)
            {                
                if (cards.Where(c => c.Value == Card.Values.Ace).Any())
                {
                    isStraight = true;
                    cards.Sort(new CardValueComparer(true));
                    for (var i = 1; i < cards.Count; i++)
                    {
                        var lowCard = cards[i - 1].Value;
                        if (lowCard == Card.Values.Ace)
                        {
                            lowCard = Card.Values.AceLow;
                        }
                        if (cards[i].Value != lowCard + 1)
                        {
                            isStraight = false;
                        }
                    }
                }
            }

            return isStraight;
        }

        private bool IsFlush(List<Card> cards)
        {
            var distinctSuits = cards.Select(c => c.Suit).Distinct().Count();
            if (distinctSuits == 1)
            {
                return true;
            }
            return false;
        }

        private bool IsFullHouse(List<Card> cards)
        {
            var hasPair = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2).Any();
            var hasGroupOfThree = cards.GroupBy(c => c.Value).Where(x => x.Count() == 3).Any();
            if (hasPair && hasGroupOfThree)
            {
                return true;
            }
            return false;
        }

        private bool IsFourOfaKind(List<Card> cards)
        {
            var hasGroupOfFour = cards.GroupBy(c => c.Value).Where(x => x.Count() == 4).Any();
            return hasGroupOfFour;
        }

        private bool IsStraightFlush(List<Card> cards)
        {
            if (IsFlush(cards) && IsStraight(cards))
            {
                return true;
            }
            return false;
        }

        private bool IsRoyalFlush(List<Card> cards)
        {
            if (IsStraightFlush(cards) 
             && cards.First().Value == Card.Values.Ten 
             && cards.Last().Value == Card.Values.Ace)
            {
                return true;
            }
            return false;
        }
    }
}
