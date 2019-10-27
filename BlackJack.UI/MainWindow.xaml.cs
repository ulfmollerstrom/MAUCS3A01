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
        private readonly Game game;
        private Dictionary<Guid, List<Image>> images;
        private Dictionary<Guid, StackPanel> panels;

        public MainWindow()
        {
            InitializeComponent();

            game = new Game
            {
                Dealer = new Dealer(),
                Players = new List<Player>
                {
                    new Player { Name = "Oleg" },
                    new Player { Name = "Olga" },
                    new Player { Name = "Svetlana" }
                },
                Shoe = ShoeFactory(NumberOfDecksInShoe.Is8)
            };

            foreach (var player in game.Players)
                DealTwoCardsToPlayer(game.Shoe, player);

            SetupPlayerPanels();


        }

        private void SetupPlayerPanels()
        {
            panels = game.Players
                .ToDictionary(player => player.Id, player =>
                    new StackPanel
                    {
                        //HorizontalAlignment = HorizontalAlignment.Left,
                        //VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(10, 0, 0, 20)
                    });

            Players.Items.Clear();
            foreach (var player in game.Players)
            {
                panels[player.Id].Children.Clear();
                SetupImages(player);
                AddNameLabel(panels[player.Id], player);
                AddChoice(panels[player.Id], player);
                AddRange(panels[player.Id], images[player.Id]);
                Players.Items.Add(new TabItem { Header = player.Name, Content = panels[player.Id] });
            }

            //PlayersPanel.Children.Clear();
            //AddRange(PlayersPanel, panels.Values);
        }

        private void AddNameLabel(Panel panel, Player player)
        {
            var label = new Label
            {
                Content=player.Name
            };
            panel.Children.Add(label);
        }

        private void AddChoice(Panel panel, Player player)
        {
            var groupPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                MaxWidth = 100
            };

            var hit = new RadioButton
            {
                GroupName = player.Id.ToString(),
                Content = "Hit!",
                HorizontalAlignment = HorizontalAlignment.Left,
                Tag = player

            };
            hit.Checked += (sender, e) => Player(sender).Stand = false;
            groupPanel.Children.Add(hit);

            var stand = new RadioButton
            {
                GroupName = player.Id.ToString(),
                Content = "Stand!",
                HorizontalAlignment = HorizontalAlignment.Right,
                Tag = player
            };
            stand.Checked += (sender, e) => Player(sender).Stand = true;
            groupPanel.Children.Add(stand);

            panel.Children.Add(groupPanel);

        }

        private void HitPlayer(Player player) => 
            DisplayResult(TakeCard(player));


        private Player TakeCard(Player player)
        {
            player.TakeCard(game.Dealer.Deal(game.Shoe));
            return player;
        }

        private static Player Player(object sender) => 
            (sender as FrameworkElement)?.Tag as Player ?? new Player();

        private Player DisplayResult(Player player)
        {
            SetupImages(player);
            RemoveOldImageElements(player.Id);
            AddTheNewImageElements(player.Id);
            return player;
        }

        private void SetupImages(Player player)
        {
            if(images==null) images=new Dictionary<Guid, List<Image>>();
            images[player.Id] = player.Hand
                .Select(CardImage)
                .Select(NewImageElement).ToList();
        }

        private void AddTheNewImageElements(Guid playerId) => 
            AddRange(panels[playerId], images[playerId]);

        private static void AddRange(Panel panel, IEnumerable<UIElement> elements)
        {
            foreach (var element in elements)
                panel.Children.Add(element);
        }

        private void RemoveOldImageElements(Guid playerId)
        {
            var toRemove = panels[playerId].Children.OfType<Image>().ToArray();
            for (var i = 0; i < toRemove.Count(); i++)
                panels[playerId].Children.Remove(toRemove[i]);
        }

        private static BitmapImage CardImage(PlayingCard card)
        {
            var uri = new Uri($"images/{card.Suite}/{card.Card}.png", UriKind.Relative);
            return new BitmapImage(uri);
        }

        private static Image NewImageElement(BitmapImage item)
        {
            return new Image { Source = item, Stretch = Stretch.None };
        }

        private void Deal_OnClick(object sender, RoutedEventArgs e)
        {
            if (game.Players.Any(p => !p.Stand.HasValue)) return;

            foreach (var player in game.Players.Where(player => !player.IsBust)) 
                TakeCard(player);

            SetupPlayerPanels();
        }
    }
}
