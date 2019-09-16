using System.Collections.Generic;
using BlackJack.Core.Enums;

namespace BlackJack.Core.Game
{
    public class SetUpGame
    {
        public static IDictionary<Cards, int> BlackJackCardValues()
        {
            return new Dictionary<Cards, int>
            {
                {Cards.Ace, 11},
                {Cards.Two, 2},
                {Cards.Three, 3},
                {Cards.Four, 4},
                {Cards.Five, 5},
                {Cards.Six, 6},
                {Cards.Seven, 7},
                {Cards.Eight, 8},
                {Cards.Nine, 9},
                {Cards.Ten, 10},
                {Cards.Jack, 10},
                {Cards.Queen, 10},
                {Cards.King, 10}
            };
        }
    }
}