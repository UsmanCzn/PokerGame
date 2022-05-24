using PokerGame.GameClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame.BusinessLogic
{
    public interface IPokerHandAssessor
    {
        PokerHandType CheckPokerHandType(PokerHand pokerHand);
    }
}
