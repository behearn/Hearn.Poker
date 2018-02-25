using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Hearn.Poker
{

    public class HandValidator
    {
        
        public Hand CheckHand(List<Card> cards)
        {

            if (cards.Count != 5)
            {
                throw new Exception("Poker hand should contain 5 cards");
            }

            if (cards.Select(c => c.ToString()).Distinct().Count() != 5)
            {
                throw new Exception("Duplicate card detected");
            }

            var hand = new Hand();

            hand.HandRank = Hand.HandRanks.HighCard;

            if (IsRoyalFlush(cards))
            {
                hand.HandRank = Hand.HandRanks.RoyalFlush;
                hand.RankedCards.AddRange(cards.OrderByDescending(c => c.Value));
            }
            else if (IsStraightFlush(cards))
            {
                hand.HandRank = Hand.HandRanks.StraightFlush;
                hand.RankedCards.AddRange(cards.OrderByDescending(c => c.Value));
            }
            else if (IsFourOfaKind(cards))
            {
                hand.HandRank = Hand.HandRanks.FourOfaKind;

                var fourOfaKindCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 4).First();
                hand.RankedCards.AddRange(fourOfaKindCards);

                hand.SideCards.AddRange(cards.Except(fourOfaKindCards));
            }
            else if (IsFullHouse(cards))
            {
                hand.HandRank = Hand.HandRanks.FullHouse;

                var threeOfaKindCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 3).First();
                hand.RankedCards.AddRange(threeOfaKindCards);

                var pairCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2).First();
                hand.RankedCards.AddRange(pairCards);
            }
            else if (IsFlush(cards))
            {
                hand.HandRank = Hand.HandRanks.Flush;
                hand.RankedCards.AddRange(cards.OrderByDescending(c => c.Value));
            }
            else if (IsStraight(cards))
            {
                hand.HandRank = Hand.HandRanks.Straight;
                if (cards.Select(c => c.Value).Max() == Card.Values.Ace
                 && cards.Select(c => c.Value).Min() == Card.Values.Two)
                {
                    hand.RankedCards.AddRange(cards.OrderByDescending(c => c.Value == Card.Values.Ace ? Card.Values.AceLow : c.Value));
                }
                else
                {
                    hand.RankedCards.AddRange(cards.OrderByDescending(c => c.Value));
                }                
            }
            else if (IsThreeOfaKind(cards))
            {
                hand.HandRank = Hand.HandRanks.ThreeOfaKind;

                var threeOfaKindCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 3).First();
                hand.RankedCards.AddRange(threeOfaKindCards);

                hand.SideCards.AddRange(cards.Except(threeOfaKindCards).OrderByDescending(c => c.Value));
            }
            else if (IsTwoPair(cards))
            {
                hand.HandRank = Hand.HandRanks.TwoPair;

                var pairCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2).OrderByDescending(x => x.Key);
                hand.RankedCards.AddRange(pairCards.First());
                hand.RankedCards.AddRange(pairCards.Last());

                hand.SideCards.AddRange(cards.Except(hand.RankedCards));
            }
            else if (IsPair(cards))
            {
                hand.HandRank = Hand.HandRanks.Pair;

                var pairCards = cards.GroupBy(c => c.Value).Where(x => x.Count() == 2).First();
                hand.RankedCards.AddRange(pairCards);

                hand.SideCards.AddRange(cards.Except(pairCards).OrderByDescending(c => c.Value));
            }
            else
            {
                hand.SideCards.AddRange(cards.OrderByDescending(c => c.Value));
            }

            return hand;

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
            var tempCards = cards.OrderBy(c => c.Value).ToList();

            var isStraight = true;

            for (var i = 1; i < tempCards.Count; i++)
            {
                if (tempCards[i].Value != tempCards[i - 1].Value + 1)
                {
                    isStraight = false;
                }
            }

            if (!isStraight)
            {
                if (cards.Where(c => c.Value == Card.Values.Ace).Any())
                {
                    isStraight = true;
                    tempCards = cards.OrderBy(c => c.Value == Card.Values.Ace ? Card.Values.AceLow : c.Value).ToList();
                    for (var i = 1; i < cards.Count; i++)
                    {
                        var lowCard = tempCards[i - 1].Value;
                        if (lowCard == Card.Values.Ace)
                        {
                            lowCard = Card.Values.AceLow;
                        }
                        if (tempCards[i].Value != lowCard + 1)
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
             && cards.OrderBy(c => c.Value).First().Value == Card.Values.Ten
             && cards.OrderBy(c => c.Value).Last().Value == Card.Values.Ace)
            {
                return true;
            }
            return false;
        }
    }
}
