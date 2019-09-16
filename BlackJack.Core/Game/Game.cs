using System.Collections.Generic;
using BlackJack.Core.Infrastucture;

namespace BlackJack.Core.Game
{
    public class Game
    {
        public Game() {}

        public Game(IEnumerable<Player.Player> players) => 
            Players = players as List<Player.Player>;

        public List<Player.Player> Players { get; set; }
        public Shoe Shoe { get; set; }
    }
}