using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.GameClasses
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }
    public enum CardSuit
    {
        Club = 0,
        Diamond = 1,
        Heart = 2,
        Spade = 3,
        Joker = 4
    }

    public enum CardValue
    {
        Unspecified = 0,
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public enum PokerHandType
    {
        Unspecified = 0,
        HighCard = 1,
        Pair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        FourOfAKind = 8,
        StraightFlush = 9,
        FiveOfAKind = 10
    }
}
