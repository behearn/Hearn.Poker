using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hearn.Poker.UnitTests
{
    [TestClass]
    public class HandValidatorTests
    {

        private HandValidator _handValidator;

        [TestInitialize]
        public void TestInitialise()
        {

            _handValidator = new HandValidator();

        }

        [TestMethod]
        public void HandValidator_CheckHand_RoyalFlush()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.RoyalFlush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_RoyalFlushRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Ace, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightFlush()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.StraightFlush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightFlushRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert
            
            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Seven, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Three, hand.RankedCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightFlushAceLow()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.StraightFlush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FourOfaKindCardsAtStart()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FourOfaKind, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FourOfaKindCardsAtEnd()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FourOfaKind, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FourOfaKindCardsSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FourOfaKind, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FourOfaKindRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert
            
            Assert.AreEqual(4, hand.RankedCards.Count);
            Assert.AreEqual(1, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Two, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Three, hand.SideCards[0].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FullHouseThreeThenTwo()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FullHouse, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FullHouseTwoThenThree()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FullHouse, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FullHouseTwoSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FullHouse, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FullHouseRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Three, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Three, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Three, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Two, hand.RankedCards[3].Value);
            Assert.AreEqual(Card.Values.Two, hand.RankedCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FullHouseThreeSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.FullHouse, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FlushClubs()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Flush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FlushSpades()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Flush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FlushHearts()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Flush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FlushDiamonds()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Flush, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_FlushRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Ace, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Queen, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Six, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Five, hand.RankedCards[3].Value);
            Assert.AreEqual(Card.Values.Four, hand.RankedCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_Straight()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Straight, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightAceLow()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Straight, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightAceLowRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert
            
            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Five, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Four, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Three, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Two, hand.RankedCards[3].Value);
            Assert.AreEqual(Card.Values.Ace, hand.RankedCards[4].Value);

        }
        
        [TestMethod]
        public void HandValidator_CheckHand_StraightAceHigh()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Straight, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_StraightAceHighRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert
            
            Assert.AreEqual(5, hand.RankedCards.Count);
            Assert.AreEqual(0, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Ace, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Queen, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Jack, hand.RankedCards[3].Value);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ThreeOfaKindCardsAtStart()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.ThreeOfaKind, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ThreeOfaKindCardsAtEnd()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.ThreeOfaKind, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ThreeOfaKindCardsSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.ThreeOfaKind, hand.HandRank);

        }
        
        [TestMethod]
        public void HandValidator_CheckHand_ThreeOfaKindRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(3, hand.RankedCards.Count);
            Assert.AreEqual(2, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Ace, hand.SideCards[0].Value);
            Assert.AreEqual(Card.Values.Ten, hand.SideCards[1].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_TwoPairCardsAtStart()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.TwoPair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_TwoPairCardsAtEnd()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.TwoPair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_TwoPairCardsSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.TwoPair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_TwoPairRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(4, hand.RankedCards.Count);
            Assert.AreEqual(1, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.King, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[2].Value);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[3].Value);
            Assert.AreEqual(Card.Values.Ace, hand.SideCards[0].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_TwoPairCardsStaggered()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.TwoPair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_PairCardsAtStart()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Spades},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Pair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_PairCardsAtEnd()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Pair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_PairCardsSplit()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Pair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_PairRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(2, hand.RankedCards.Count);
            Assert.AreEqual(3, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[0].Value);
            Assert.AreEqual(Card.Values.Ten, hand.RankedCards[1].Value);
            Assert.AreEqual(Card.Values.Ace, hand.SideCards[0].Value);
            Assert.AreEqual(Card.Values.King, hand.SideCards[1].Value);
            Assert.AreEqual(Card.Values.Queen, hand.SideCards[2].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_PairCardsStaggered()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.Pair, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_HighCard()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(Hand.HandRanks.HighCard, hand.HandRank);

        }

        [TestMethod]
        public void HandValidator_CheckHand_HighCardRankedCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(0, hand.RankedCards.Count);
            Assert.AreEqual(5, hand.SideCards.Count);
            Assert.AreEqual(Card.Values.Ace, hand.SideCards[0].Value);
            Assert.AreEqual(Card.Values.King, hand.SideCards[1].Value);
            Assert.AreEqual(Card.Values.Ten, hand.SideCards[2].Value);
            Assert.AreEqual(Card.Values.Six, hand.SideCards[3].Value);
            Assert.AreEqual(Card.Values.Two, hand.SideCards[4].Value);

        }

        [TestMethod]
        public void HandValidator_CheckHand_InvalidHandLessThan5()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts}
            };

            //Act

            var message = "";
            try
            {
                var hand = _handValidator.CheckHand(cards);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //Assert

            Assert.AreEqual("Poker hand should contain 5 cards", message);

        }

        [TestMethod]
        public void HandValidator_CheckHand_InvalidHandMoreThan5()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Hearts}
            };

            //Act

            var message = "";
            try
            {
                var hand = _handValidator.CheckHand(cards);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //Assert

            Assert.AreEqual("Poker hand should contain 5 cards", message);

        }

        [TestMethod]
        public void HandValidator_CheckHand_CardOrderMaintained()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Hearts}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);
            
            //Assert

            Assert.AreEqual("King Diamonds", cards[0].ToString());
            Assert.AreEqual("Six Clubs", cards[1].ToString());
            Assert.AreEqual("Ace Diamonds", cards[2].ToString());
            Assert.AreEqual("Ten Hearts", cards[3].ToString());
            Assert.AreEqual("Three Hearts", cards[4].ToString());

        }

        [TestMethod]
        public void HandValidator_CheckHand_DuplicateCardFound()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Hearts}
            };

            //Act

            var message = "";
            try
            {
                var hand = _handValidator.CheckHand(cards);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //Assert

            Assert.AreEqual("Duplicate card detected", message);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedRankedCardsOnly()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Six, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x50DA654; //84,780,628

            Assert.AreEqual(expectedScore, hand.Score);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedWithSideCards()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Seven, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x1022E74; //16,920,180

            Assert.AreEqual(expectedScore, hand.Score);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedAceHighStraight()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x40EDCBA; //68,082,874

            Assert.AreEqual(expectedScore, hand.Score);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedAceLowStraight()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Diamonds},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Hearts},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Spades}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x4054321; //67,453,729

            Assert.AreEqual(expectedScore, hand.Score);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedRoyalFlush()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Ten, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Jack, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Queen, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.King, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x90EDCBA; //151,968,954

            Assert.AreEqual(expectedScore, hand.Score);

        }

        [TestMethod]
        public void HandValidator_CheckHand_ScoreCalculatedAceLowStraightFlush()
        {

            //Arrange

            var cards = new List<Card>()
            {
                new Card() { Value = Card.Values.Ace, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Five, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Four, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Three, Suit = Card.Suits.Clubs},
                new Card() { Value = Card.Values.Two, Suit = Card.Suits.Clubs}
            };

            //Act

            var hand = _handValidator.CheckHand(cards);

            //Assert

            var expectedScore = 0x8054321; //134,562,593

            Assert.AreEqual(expectedScore, hand.Score);

        }
    }
}
