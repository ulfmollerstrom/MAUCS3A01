using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Player
{
    public class Dealer : Player
    {
        public new string Name { get; } = "Dealer";

        public PlayingCard Deal(Shoe shoe) => shoe.DealCard();
    }
}