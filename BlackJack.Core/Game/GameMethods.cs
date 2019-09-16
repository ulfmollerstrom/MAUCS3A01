using System.Collections.Generic;
using BlackJack.Core.Exceptions;
using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Game
{
    public static class GameMethods
    {

        public static void DealTwoCardsToPlayer(Shoe shoe, Player.Player player)
        {
            if (shoe.Count < 2)
                throw new NotEnoughCardsExeption();

            player.TakeCards(shoe.DealCard(), shoe.DealCard());
        }
    }
}