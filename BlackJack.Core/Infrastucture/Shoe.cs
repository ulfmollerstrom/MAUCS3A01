//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System.Collections.Generic;
using BlackJack.Core.Common;

namespace BlackJack.Core.Infrastucture
{
    public class Shoe
    {
        private Stack<PlayingCard> shoe;

        public Shoe(IEnumerable<PlayingCard> playingCards) => 
            shoe = new Stack<PlayingCard>(playingCards);

        public int Count => shoe.Count;

        public PlayingCard DealCard() => shoe.Pop();

        public void Reshuffle()
        {
            var playingcards = new List<PlayingCard>();
            playingcards.AddRange(shoe);
            playingcards.Random();
            shoe = new Stack<PlayingCard>(playingcards);
        }

        //For testing
        internal PlayingCard Peek => shoe.Peek();
    }
}