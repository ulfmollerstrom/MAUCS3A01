//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"


//https://en.wikipedia.org/wiki/Blackjack

using System.Collections.Generic;
using System.Linq;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastucture;
using BlackJack.Core.Player;
using NUnit.Framework;
using static BlackJack.Core.Common.DeckAndCardMethods;
using static BlackJack.Core.Game.GameMethods;
using static BlackJack.Core.Factories.GameFactories;
using static BlackJack.Core.Factories.Factories;
using static BlackJack.Core.Game.SetUpGame;


namespace BlackJack.Core.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanCreateASuiteOfCards()
        {
            //-- Arrange//-- Act
            var suiteOfCards = SuiteFactory(Suites.Hearts, BlackJackCardValues());

            //-- Assert
            Assert.IsNotNull(suiteOfCards);
            Assert.AreEqual(Suites.Hearts, suiteOfCards.Suite);
            Assert.IsNotEmpty(suiteOfCards.Values);
        }

        [Test]
        public void CanCreateADeckOfCards()
        {
            //-- Arrange
            var expected = 52;

            //-- Act
            var deckOfCards = DeckFactory(BlackJackCardValues()).ToList();

            //-- Assert
            Assert.IsNotNull(deckOfCards);
            Assert.AreEqual(expected, deckOfCards.Count);
        }

        [Test]
        public void CardsAreScrambled()
        {
            //-- Arrange
            var deckOfCards = DeckFactory(BlackJackCardValues()).ToList();//Omit ToList in working code

            var aceOfHearts = new {deckOfCards[0].Suite, deckOfCards[0].Card, deckOfCards[0].Value };
            var twoOfHearts = new { deckOfCards[1].Suite, deckOfCards[1].Card, deckOfCards[1].Value };
            var threeOfHearts = new { deckOfCards[2].Suite, deckOfCards[2].Card, deckOfCards[2].Value };

            //-- Act
            var scrambled = ShuffleCards(deckOfCards).ToArray();

            var foo = new { scrambled[0].Suite, scrambled[0].Card, scrambled[0].Value };
            var bar = new { scrambled[1].Suite, scrambled[1].Card, scrambled[1].Value };
            var baz = new { scrambled[2].Suite, scrambled[2].Card, scrambled[2].Value };

            //-- Assert

            var assert = (aceOfHearts == foo) && (twoOfHearts == bar) && (threeOfHearts == baz);
            Assert.IsFalse(assert);
        }

        [Test]
        public void DynamicEquals()
        {
            //-- Arrange
            var deckOfCards = DeckFactory(BlackJackCardValues()).ToList();

            var aceOfHearts = new PlayingCard(Suites.Hearts, Cards.Ace, 11);
            var aceOfHeartsFromDeck = deckOfCards[0];

            //-- Act

            //-- Assert
            Assert.IsTrue(aceOfHearts.Equals(aceOfHeartsFromDeck));
            Assert.IsTrue(aceOfHearts.AreEqual(aceOfHeartsFromDeck));

        }

        [Test]
        public void CreateADealersShoe()
        {
            //-- Arrange
            var numberODecksInShoe = NumberOfDecksInShoe.Is4;
            var expected = (int) numberODecksInShoe*52;

            //-- Act
            var shoe = ShoeFactory(numberODecksInShoe);

            //-- Assert
            Assert.AreEqual(expected, shoe.Count);
        }

        [Test]
        public void GetHandScore()
        {
            //-- Arrange
            var hand = new Hand
            {
                new PlayingCard(Suites.Hearts, Cards.Ten, 10),
                new PlayingCard(Suites.Hearts, Cards.Ten, 10)
            };
            var expected = 20;

            //-- Act

            //-- Assert
            Assert.AreEqual(expected,hand.Score);

        }

        [Test]
        public void Calculate21With2Cards()
        {
            //-- Arrange
            var hand = new Hand
            {
                new PlayingCard(Suites.Hearts, Cards.Ten, 10),
                new PlayingCard(Suites.Hearts, Cards.Ace, 11)
            };
            var expected = 21;

            //-- Act

            //-- Assert
            Assert.AreEqual(expected, hand.Score);

        }

        [Test]
        public void Calculate21With3Cards()
        {
            //-- Arrange
            var hand = new Hand
            {
                new PlayingCard(Suites.Hearts, Cards.Ten, 10),
                new PlayingCard(Suites.Hearts, Cards.Ten, 10),
                new PlayingCard(Suites.Hearts, Cards.Ace, 11)
            };

            var expected = 21;

            //-- Act

            //-- Assert
            Assert.AreEqual(expected, hand.Score);

        }

        [Test]
        public void CreatePlayerDealCardsAndGetScore()
        {
            //-- Arrange
            var player = new Player.Player();
            var expected = 10;

            //-- Act
            player.TakeCard(new PlayingCard(Suites.Hearts, Cards.Ten, 10));
            var actual = player.Score;

            //-- Assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void DealTwoCardsToPlayerAndGetScore()
        {
            //-- Arrange
            var playingCards = new List<PlayingCard>
            {
                new PlayingCard(Suites.Hearts, Cards.Ten, 10),
                new PlayingCard(Suites.Hearts, Cards.Ten, 10)
            };

            var shoe = new Shoe(playingCards);
            var player = new Player.Player();
            var expected = 20;

            //-- Act
            DealTwoCardsToPlayer(shoe, player);
            var actual = player.Score;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShuffleStack()
        {
            //-- Arrange
            var shoe = ShoeFactory(NumberOfDecksInShoe.Is8);
            var expected = new PlayingCard(shoe.Peek);

            //-- Act
            shoe.Reshuffle();
            var actual = new PlayingCard(shoe.Peek);

            //-- Assert
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void RunGameStart()
        {
            //-- Arrange

            var game = new Game.Game
            {
                Players = new List<Player.Player> { new Player.Player { Name = "Nisse" } },
                Shoe = ShoeFactory(NumberOfDecksInShoe.Is8)
            };

            //-- Act


            //-- Assert

        }


    }
}
