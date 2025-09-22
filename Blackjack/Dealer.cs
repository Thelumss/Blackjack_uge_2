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
        // start for hvad dealer gøre i sin tur
        public String Dealerturn()
        {
            return "stand";
            return "hit";
        }

    }
}
