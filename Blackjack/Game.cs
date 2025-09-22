using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {

        List<Card> deck = new List<Card>();
        public Game() {
                
            for (int i = 1; i <= 4; i++)
                {

                for (int j = 2; j <= 14; j++)
                {
                    Card card = new Card(j,i,j);
                    deck.Add(card);
                }
                }
            Console.WriteLine(deck[10].Suit);
            Console.WriteLine(deck[10].Name);
            Console.WriteLine(deck[10].Value);
        }

    }
}
