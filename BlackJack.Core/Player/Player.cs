//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System;
using System.Collections;
using System.Collections.Generic;
using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Player
{
    public class Player
    {
        private readonly Hand hand = new Hand();

        public string Name { get; set; }
        public bool Stand { get; set; } = false;
        public bool IsBust => Score > 21;
        public bool HasBlackJack => Score == 21;
        public int Score => hand.Score;
        public Guid Id { get; } = Guid.NewGuid();
        public IList<PlayingCard> Hand => new List<PlayingCard>(hand);

        public void TakeCard(PlayingCard playingCard)
        {
            hand.Add(playingCard);
        }

        public void TakeCards(params PlayingCard[] playingCards)
        {
            if (playingCards == null)
                throw new ArgumentNullException(nameof(playingCards));

            foreach (var playingCard in playingCards)
                TakeCard(playingCard);
        }

    }
}