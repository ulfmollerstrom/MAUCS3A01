using System.Collections.ObjectModel;
using System.Linq;
using BlackJack.Core.Enums;
using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Player
{
    internal class Hand : ObservableCollection<PlayingCard>
    {
        public int Score => CalcScore();

        private int CalcScore()
        {
            var score = Items.Sum(card => card.Value);
            var aces = Items.Count(card => card.Card == Cards.Ace);

            while ((score > 21) && (aces > 0))
            {
                score -= 10;
                aces--;
            }

            return score;
        }
    }
}