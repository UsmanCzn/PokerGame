using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.GameClasses
{
    public class PokerHand : List<Card>
    {
        public PokerHand()
        { }
        public PokerHand(params Card[] pokerhandCards)
        {
            AddRange(pokerhandCards);
        }
    }
}
