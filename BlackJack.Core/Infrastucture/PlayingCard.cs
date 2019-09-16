using System;
using BlackJack.Core.Common;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Infrastucture
{
    public class PlayingCard : IEquatable<PlayingCard>
    {

        public PlayingCard(Suites suite, Cards card, int value)
        {
            Suite = suite;
            Card = card;
            Value = value;
        }

        //For testing
        internal PlayingCard(PlayingCard playingCard)
        {
            Suite = playingCard.Suite;
            Card = playingCard.Card;
            Value = playingCard.Value;
        }

        public Suites Suite { get; set; }
        public Cards Card { get; set; }
        public int Value { get; set; }

        public override bool Equals(object other) => 
            this.AreEqual(other as PlayingCard);
        public bool Equals(PlayingCard other) => this.AreEqual(other);


    }
}