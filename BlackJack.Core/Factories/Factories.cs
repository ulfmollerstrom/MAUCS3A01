//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System.Collections.Generic;
using System.Linq;
using BlackJack.Core.Common;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastucture;
using static BlackJack.Core.Enums.EnumExtensions;
using static BlackJack.Core.Game.SetUpGame;

namespace BlackJack.Core.Factories
{
    public static class Factories
    {
        /// <summary>
        /// Creates a suite of cards
        /// </summary>
        /// <param name="suite">Hearts, Diamonds, Clubs or Spades</param>
        /// <param name="values">card values</param>
        /// <returns>a non-random sequence of cards</returns>
        public static SuiteOfCards SuiteFactory(Suites suite, IDictionary<Cards, int> values)
        {
            //TODO: Set to private before release and remove create test
            return new SuiteOfCards {Suite = suite, Values = values};
        }

        /// <summary>
        /// Creates a deck of cards
        /// </summary>
        /// <param name="cardValues">values of the cards specific to a card game</param>
        /// <returns>a non-random sequence of playing cards</returns>
        public static IEnumerable<PlayingCard> DeckFactory(IDictionary<Cards, int> cardValues)
        {
            var deckOfCards = EnumToList<Suites>()
                .Select(suite => SuiteFactory(suite, cardValues))
                .SelectMany(suite => suite.Values,
                (suite, value) => new PlayingCard(suite.Suite, value.Key, value.Value));

            return deckOfCards;
        }
    }
}