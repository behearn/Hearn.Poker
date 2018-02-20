using System;
using System.Collections.Generic;
using System.Text;

namespace Hearn.Poker
{
    public class CardValueComparer : IComparer<Card>
    {

        private bool _aceLow;

        public CardValueComparer()
        {
            _aceLow = false;
        }

        public CardValueComparer(bool aceLow)
        {
            _aceLow = aceLow;
        }

        public int Compare(Card x, Card y)
        {
            var xValue = x.Value;
            var yValue = y.Value;

            if (_aceLow)
            {
                if (x.Value == Card.Values.Ace)
                {
                    xValue = Card.Values.AceLow;
                }
                if (y.Value == Card.Values.Ace)
                {
                    yValue = Card.Values.AceLow;
                }
            }

            return xValue - yValue;
        }
    }
}
