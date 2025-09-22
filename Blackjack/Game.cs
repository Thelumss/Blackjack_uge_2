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

            for (int i = 0; i < deck.Count; i++)
            {
                Console.WriteLine(deck[i].Name);
                Console.WriteLine(deck[i].Suit);
                Console.WriteLine(deck[i].Value);
                Console.WriteLine();
            }
        }

    }
}
