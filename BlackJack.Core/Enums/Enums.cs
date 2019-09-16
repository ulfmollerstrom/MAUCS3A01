//Ulf Möllerström
//2019-09-18
//MAUCS3A01: "Blackjack Game"

using System.ComponentModel;

namespace BlackJack.Core.Enums
{
    public enum Suites
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Cards
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum NumberOfDecksInShoe
    {
        [Description("2")]
        Is2 = 2,
        [Description("4")]
        Is4 = 4,
        [Description("6")]
        Is6 = 6,
        [Description("8")]
        Is8 = 8
    }
}
