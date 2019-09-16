//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System.Collections.Generic;
using BlackJack.Core.Exceptions;
using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Common
{
    public static class DeckAndCardMethods
    {
        public static IEnumerable<PlayingCard> ShuffleCards(IEnumerable<PlayingCard> cards)
        {
            var tmp = cards as IList<PlayingCard>;
            return tmp.Randomize();
        }

        /// <summary>
        /// Method makes use of the dynamic.Equals that constructs equality operators and
        /// GetHashCode for the anonymous type
        /// </summary>
        /// <param name="card">a playingcard</param>
        /// <param name="otherCard">the playingcard to compare to</param>
        /// <returns></returns>
        public static bool AreEqual(this PlayingCard card, PlayingCard otherCard)
        {
            return DynamicPlayingCard(card).Equals(DynamicPlayingCard(otherCard));
        }

        /// <summary>
        /// Method that creates a dynamic playingcard, with the same props
        /// </summary>
        /// <param name="card">the card to convert</param>
        /// <returns>a dynamic representation of the playingcard</returns>
        private static dynamic DynamicPlayingCard(PlayingCard card)
        {
            return new {card.Suite, card.Card, card.Value};
        }
    }
}