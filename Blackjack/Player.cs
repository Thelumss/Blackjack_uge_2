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
        private double money = 0;
        private double wager = 0;
        private bool isbust = false;

        public Player(float money)
        {
            this.Money = money;
        }

        public void ClearHand()
        {
            hand.Clear();
        }


        // måde på at få spillers hånd
        public List<Card> Hand { get => hand; set => hand = value; }
        public bool Isbust { get => isbust; set => isbust = value; }
        public double Money { get => money; set => money = value; }
        public double Wager { get => wager; set => wager = value; }
    }
}
