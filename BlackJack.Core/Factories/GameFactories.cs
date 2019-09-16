//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System.Collections.Generic;
using BlackJack.Core.Enums;
using BlackJack.Core.Game;
using BlackJack.Core.Infrastucture;
using static BlackJack.Core.Common.DeckAndCardMethods;

namespace BlackJack.Core.Factories
{
    public static class GameFactories
    {
        /// <summary>
        /// Creates a dealers shoe with the specified number of decks
        /// </summary>
        /// <param name="numberOfDecksInShoe">number of decks</param>
        /// <returns>a random sequence of playing cards</returns>
        public static Shoe ShoeFactory(NumberOfDecksInShoe numberOfDecksInShoe)
        {
            var playingCards = new List<PlayingCard>();
            for (var i = 0; i < (int)numberOfDecksInShoe; i++)
            {
                playingCards.AddRange(Factories.DeckFactory(SetUpGame.BlackJackCardValues()));
            }

            return new Shoe(ShuffleCards(playingCards));
        }
    }
}