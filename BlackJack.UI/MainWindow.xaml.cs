using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackJack.Core.Enums;
using BlackJack.Core.Game;
using BlackJack.Core.Infrastucture;
using BlackJack.Core.Player;
using static BlackJack.Core.Common.DeckAndCardMethods;
using static BlackJack.Core.Game.GameMethods;
using static BlackJack.Core.Factories.GameFactories;
using static BlackJack.Core.Factories.Factories;
using static BlackJack.Core.Game.SetUpGame;

namespace BlackJack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var game = new Core.Game.Game
            {
                Dealer = new Dealer(),
                Players = new List<Player>
                {
                    new Player { Name = "Oleg" },
                    new Player { Name = "Olga" }
                },
                Shoe = ShoeFactory(NumberOfDecksInShoe.Is8)
            };

            foreach (var player in game.Players)
                DealTwoCardsToPlayer(game.Shoe, player);

            var images = game.Players
                .ToDictionary(player => player.Id, player => player.Hand.Select(CardImage)
                .Select(item => new Image {Source = item, Stretch = Stretch.None})
                .ToList());

            var panels = game.Players
                .ToDictionary(player => player.Id, player =>
                    new StackPanel
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Height = 500,
                        Width = 500
                    });

            foreach (var player in game.Players)
                AddRange(panels[player.Id], images[player.Id]);

            var playersPanel = new StackPanel
            {
                Name = "playersPanel",
                Orientation = Orientation.Horizontal
            };
            AddRange(playersPanel, panels.Values);

            aGrid.Children.Add(playersPanel);

            game.Players.Last()?.TakeCard(game.Dealer.Deal(game.Shoe));

            images[game.Players.Last().Id] = game.Players.Last()?.Hand
                .Select(CardImage)
                .Select(item => new Image { Source = item, Stretch = Stretch.None }).ToList();

            panels[game.Players.Last().Id].Children.Clear();
            AddRange(panels[game.Players.Last().Id], images[game.Players.Last().Id]);
        }

        private static void AddRange(Panel panel, IEnumerable<UIElement> elements)
        {
            foreach (var element in elements)
                panel.Children.Add(element);
        }

        private static BitmapImage CardImage(PlayingCard card)
        {
            var uri = new Uri($"images/{card.Suite}/{card.Card}.png", UriKind.Relative);
            return new BitmapImage(uri);
        }
    }
}
