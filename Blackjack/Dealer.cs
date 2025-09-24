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
        public bool Dealerturn(int score)
        {
            if (score <= 17) 
            {
                Console.WriteLine("HIT");
            return true;
            }else
            {
                Console.WriteLine("STAND");
                return false;
            }
        }

    }
}
