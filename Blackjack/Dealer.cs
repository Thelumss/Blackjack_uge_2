using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // the dealer inherites from the player because they have a lot in common 
    class Dealer : Player
    {
        public Dealer(float money) : base(money)
        {

        }


        // the dealer turn and action takes the deck from the game
        public void Dealerturn(List<Card> deck)
        {
            bool turnloop = true;
            while (turnloop)
            {
                print(this.Hand[0]);

                // calculaes the score of the hand less then or eqcual to 17 it is a hit 
                if (scoreCalc(this.Hand[0]) <= 17)
                {

                    this.Hand[0].Add(deck[0]);
                    deck.Remove(this.Hand[0][this.Hand[0].Count - 1]);

                    if (scoreCalc(this.Hand[0]) > 21)
                    {
                        this.Isbust[0] = true;
                    }
                }
                // if the score is more then 17 the dealer end it's turn
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
