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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.RoyalFlush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.StraightFlush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.StraightFlush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FourOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FourOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FourOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FullHouse, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FullHouse, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FullHouse, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.FullHouse, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Flush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Flush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Flush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Flush, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Straight, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Straight, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Straight, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.ThreeOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.ThreeOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.ThreeOfaKind, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.TwoPair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.TwoPair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.TwoPair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.TwoPair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Pair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Pair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Pair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.Pair, handRank);

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

            var handRank = _handValidator.CheckHand(cards);

            //Assert

            Assert.AreEqual(HandValidator.HandRanks.HighCard, handRank);

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
                var handRank = _handValidator.CheckHand(cards);
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
                var handRank = _handValidator.CheckHand(cards);
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

            var handRank = _handValidator.CheckHand(cards);
            
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
                var handRank = _handValidator.CheckHand(cards);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //Assert

            Assert.AreEqual("Duplicate card detected", message);

        }

    }
}
