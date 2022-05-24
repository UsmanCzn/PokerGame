using PokerGame.BusinessLogic;
using PokerGame.GameClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame.Infrastructure
{
    public class PokenHandImplementation:IPokerHandAssessor
    {

        #region Arrange Cards
        /// <summary>
        /// The cards are arranged in ascending order, so that the Hand Type is easily seen.
        /// If an Ace is to be used as a 1 (before 2) in a Straight, 
        /// then the Ace will be at the beginning, otherwise, it will be at the end.
        /// </summary>
        /// <param name="pokerHand">The poker hand to be arranged.</param>
        void ArrangeCards(PokerHand pokerHand)
        {
            //First determine whether the poker hand is a Straight or a Straight Flush.
            //The IsStraight function also sorts the Poker Hand in ascending order.
            bool straight = IsStraight(pokerHand);

            //Move Aces to the end if:
            if (!straight || //Not a straight
                pokerHand[4].Value == CardValue.King)//Straight with a king at the end
            {
                //Move all Aces To the End
                while (pokerHand[0].Value == CardValue.Ace)
                {
                    pokerHand.Add(pokerHand[0]);
                    pokerHand.RemoveAt(0);
                }
            }
        }
        #endregion

        #region Compare Hands
        public int[] CompareHands(PokerHand[] pokerHands)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Find Sets of Cards With Same Value
        /// <summary>
        /// Finds sets of cards that have the same value.
        /// This is necessary to identify the followig Hand Types: 
        /// Four of a Kind, Full House, Three of a Kind, Two-Pair, Pair
        /// </summary>
        /// <param name="pokerHand">The poker hand to be evaluated.</param>
        /// <param name="sameValueSet1">First set of cards found with the same value.</param>
        /// <param name="sameValueSet2">Second set of cards found with the same value.</param>
        void FindSetsOfCardsWithSameValue(PokerHand pokerHand, out List<int> sameValueSet1, out List<int> sameValueSet2)
        {
            //Arrange the cards in logical order.
            ArrangeCards(pokerHand);

            //Find sets of cards with the same value.
            int index = 0;
            sameValueSet1 = FindSetsOfCardsWithSameValue_Helper(pokerHand, ref index);
            sameValueSet2 = FindSetsOfCardsWithSameValue_Helper(pokerHand, ref index);
        }
        List<int> FindSetsOfCardsWithSameValue_Helper(PokerHand pokerHand_ArrangedCorrectly, ref int index)
        {
            List<int> sameCardSet = new List<int>();
            for (; index < 4; index++)
            {
                int currentCard_intValue = (int)pokerHand_ArrangedCorrectly[index].Value;
                int nextCard_intValue = (int)pokerHand_ArrangedCorrectly[index + 1].Value;
                if (currentCard_intValue == nextCard_intValue)
                {
                    if (sameCardSet.Count == 0)
                        sameCardSet.Add(currentCard_intValue);
                    sameCardSet.Add(currentCard_intValue);
                }
                else if (sameCardSet.Count > 0)
                {
                    index++;
                    break;
                }
            }
            return sameCardSet;
        }
        #endregion

        #region Determine Poker Hand Type
        /// <summary>
        /// Determines the poker hand type. For example: Straight Flush or Four of a Kind.
        /// </summary>
        /// <param name="pokerHand">The poker hand to be evaluated.</param>
        /// <returns>The poker hand type.
        /// For example: Straight Flush or Four of a Kind.</returns>
        public PokerHandType CheckPokerHandType(PokerHand pokerHand)
        {
            //Check whether all cards are in the same suit
            bool allSameSuit = pokerHand.GroupBy(card => card.Suit).Count() == 1;

            //Check whether the Poker Hand Type is: Straight
            bool straight = IsStraight(pokerHand);

            //Determine Poker Hand Type
            if (allSameSuit && straight)
                return PokerHandType.StraightFlush;

            if (allSameSuit)
                return PokerHandType.Flush;

            if (straight)
                return PokerHandType.Straight;

            //Find sets of cards with the same value.
            //Example: QQQ KK
            List<int> sameCardSet1, sameCardSet2;
            FindSetsOfCardsWithSameValue(pokerHand, out sameCardSet1, out sameCardSet2);

            //Continue Determining Poker Hand Type
            if (sameCardSet1.Count == 4)
                return PokerHandType.FourOfAKind;

            if (sameCardSet1.Count + sameCardSet2.Count == 5)
                return PokerHandType.FullHouse;

            if (sameCardSet1.Count == 3)
                return PokerHandType.ThreeOfAKind;

            if (sameCardSet1.Count + sameCardSet2.Count == 4)
                return PokerHandType.TwoPair;

            if (sameCardSet1.Count == 2)
                return PokerHandType.Pair;

            return PokerHandType.HighCard;
        }
        #endregion

       

        #region Is Straight
        /// <summary>
        /// Determines whether the card values are in sequence. 
        /// The hand type would then be either Straight or Straight Flush.
        /// </summary>
        /// <param name="pokerHand">The poker hand to be evaluated.</param>
        /// <returns>Boolean indicating whether the card values are in sequence.</returns>
        bool IsStraight(PokerHand pokerHand)
        {
            //Sort ascending
            pokerHand.Sort((pokerCard1, pokerCard2) =>
            pokerCard1.Value.CompareTo(pokerCard2.Value));

            //Determines whether the card values are in sequence.
            return
                //Check whether the last 4 cards are in sequence.
                pokerHand[1].Value == pokerHand[2].Value - 1 &&
                pokerHand[2].Value == pokerHand[3].Value - 1 &&
                pokerHand[3].Value == pokerHand[4].Value - 1
                &&
                (
                //Check that the first two cards are in sequence
                pokerHand[0].Value == pokerHand[1].Value - 1
                //or the first card is an Ace and the last card is a King.
                || pokerHand[0].Value == CardValue.Ace && pokerHand[4].Value == CardValue.King
                );
        }
        #endregion

    }
}
