using PokerGame.BusinessLogic;
using PokerGame.GameClasses;
using PokerGame.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Poker Gamers!");

            Console.WriteLine("");

            //Royal Flush
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Spade, Value = CardValue.King },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace }
                ));

            //Flush
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Spade, Value = CardValue.King },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Two },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Three }
                ));

            //Straight
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Jack },
                new Card { Suit = CardSuit.Club, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Spade, Value = CardValue.King },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace }
                ));

            //Four of a Kind
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

            //Full House
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

            //Three of a Kind
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Nine },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

            //Two Pair
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.King },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Ten },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

            //Pair
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.King },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

            //High Card
            DeterminePokerHandType_and_writeToConsole(new PokerHand(
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ace },
                new Card { Suit = CardSuit.Club, Value = CardValue.Nine },
                new Card { Suit = CardSuit.Diamond, Value = CardValue.King },
                new Card { Suit = CardSuit.Heart, Value = CardValue.Queen },
                new Card { Suit = CardSuit.Spade, Value = CardValue.Ten }
                ));

        }


        static string EnumToTitle(Enum enumToConvert)
        {
            return System.Text.RegularExpressions.Regex
            .Replace(enumToConvert.ToString(), "[A-Z]", " $0").Trim();
        }
        static void DeterminePokerHandType_and_writeToConsole(PokerHand pokerHand)
        {
            IPokerHandAssessor assessor = new PokenHandImplementation();
            PokerHandType handType = assessor.CheckPokerHandType(pokerHand);
            Console.WriteLine("Poker hand type determined: " + EnumToTitle(handType));
        }
    }
}
