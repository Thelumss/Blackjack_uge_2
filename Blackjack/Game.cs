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
        }

        public void GameLoop() {
            Player player = new Player();
            Dealer dealer = new Dealer();  
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }

            dealer.Hand.Add(deck[0]);
            deck.Remove(dealer.Hand[dealer.Hand.Count - 1]);
            dealer.Hand.Add(deck[0]);
            deck.Remove(dealer.Hand[dealer.Hand.Count - 1]);


            player.Hand.Add(deck[0]);
            deck.Remove(player.Hand[player.Hand.Count - 1]);
            player.Hand.Add(deck[0]);
            deck.Remove(player.Hand[player.Hand.Count - 1]);

            for (int i = 0; i < dealer.Hand.Count; i++)
            {
                Console.WriteLine(player.Hand[i].Name);
                Console.WriteLine(player.Hand[i].Suit);
                Console.WriteLine(player.Hand[i].Value);
                Console.WriteLine();
            }

            for (int i = 0; i < dealer.Hand.Count; i++)
            {
                Console.WriteLine(dealer.Hand[i].Name);
                Console.WriteLine(dealer.Hand[i].Suit);
                Console.WriteLine(dealer.Hand[i].Value);
                Console.WriteLine();
            }


        }

    }
}
