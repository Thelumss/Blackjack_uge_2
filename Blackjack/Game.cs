using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

        public void GameLoop()
        {

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


            player.Hand.Add(deck[0]);
            deck.Remove(player.Hand[player.Hand.Count - 1]);
            player.Hand.Add(deck[0]);
            deck.Remove(player.Hand[player.Hand.Count - 1]);
            bool gameLoop = true;
            while (gameLoop)
            {
                Console.Clear();

                print(player.Hand);
                int score = scoreCalc(player.Hand);

                Console.WriteLine("score:"+score+"\n");
                

                Console.WriteLine("" +
                    "Type HIT to get a other card \n" +
                    "Type STAND to be done getting cards \n" +
                    "Anything else and the dealer will eject you from the table \n");

                string respone = Console.ReadLine();
                
                
                switch (respone.ToUpper())
                {
                    case "HIT":
                        player.Hand.Add(deck[0]);
                        deck.Remove(player.Hand[player.Hand.Count - 1]);
                        break;
                    case "STAND":
                        break;
                    default:
                        System.Environment.Exit(1);
                        break;
                }
                if (scoreCalc(player.Hand) > 21) 
                { 
                    gameLoop = false;
                    Console.Clear();
                    print(player.Hand);
                    Console.WriteLine("you when bust with a score: "+scoreCalc(player.Hand));
                }
            }
        }

        public int scoreCalc(List<Card> cards){
            int score = 0;
            List<Card> decks = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value != 0)
                {
                score += cards[i].Value;

                }else
                {
                    decks.Add(cards[i]);
                }
            }
            if (decks.Count > 0)
                for (int i = 0; i < decks.Count; i++)
                {
                    {
                        if (score + 11 >= 21) { score += 11; } else { score += 1; }

                    }
                }
            return score;
        }

        public void print(List<Card> hand) 
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i].Name + " of " + hand[i].Suit);
            }
        }

    }
}
