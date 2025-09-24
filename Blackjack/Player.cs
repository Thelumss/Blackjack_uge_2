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
        private List<List<Card>> hand = new List<List<Card>>();
        private double money = 0;
        private List<double> wager = new List<double>();
        private List<bool> isbust = new List<bool>();

        public Player(float money)
        {
            this.Money = money;
            this.hand.Add(new List<Card>());
        }

        public void ClearHand()
        {
            Hand.Clear();
        }


        // måde på at få spillers hånd

        public List<List<Card>> Hand { get => hand; set => hand = value; }
        public double Money { get => money; set => money = value; }
        public List<double> Wager { get => wager; set => wager = value; }
        public List<bool> Isbust { get => isbust; set => isbust = value; }
    }
}
