using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // dealer arver fra plkayer fordi de kommer til at have meget til fældeds men dealer skal kunne lidt mere
    class Dealer: Player
    {
        public Dealer(float money) : base(money)
        {

        }


        // start for hvad dealer gøre i sin tur
        public void Dealerturn(List<Card> deck)
        {
            bool turnloop = true;
            while (turnloop)
            {
                print(this.Hand[0]);

                if (scoreCalc(this.Hand[0]) <= 17)
                {

                    this.Hand[0].Add(deck[0]);
                    deck.Remove(this.Hand[0][this.Hand[0].Count - 1]);

                    if (scoreCalc(this.Hand[0]) > 21)
                    {
                        this.Isbust[0] = true;
                    }
                }
                else
                {
                    turnloop = false;
                    Console.Clear();
                    print(this.Hand[0]);
                    Console.ReadLine();
                }
            }
        }
    }
}
