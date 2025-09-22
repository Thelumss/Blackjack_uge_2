using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        // spillers hånd 
        private List<Card> hand = new List<Card>();

        // måde på at få spillers hånd
        public List<Card> Hand { get => hand; set => hand = value; }
    }
}
