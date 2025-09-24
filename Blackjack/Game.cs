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
        Player player = new Player();
        Dealer dealer = new Dealer();
        // sets up the game and as in the cards 
        public Game() {
            for (int d = 1; d <= 1 ; d++)
            {
            for (int s = 1; s <= 4; s++)
                {

                    for (int v = 2; v <= 14; v++)
                    {
                        Card card = new Card(v,s,v);
                        deck.Add(card);
                    }
                }
                
            }
        }

        public void GameLoop()
        {

            
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

            this.dealer.Hand.Add(deck[0]);
            this.deck.Remove(dealer.Hand[dealer.Hand.Count - 1]);


            this.player.Hand.Add(deck[0]);
            this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);
            this.player.Hand.Add(deck[0]);
            this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);

            bool gameLoop = true;
            
            while (gameLoop)
            {
                Console.Clear();

                print(this.player.Hand);
                int score = scoreCalc(this.player.Hand);

                Console.WriteLine("score:"+score+"\n");
                

                Console.WriteLine("" +
                    "Type HIT to get a other card \n" +
                    "Type STAND to be done getting cards \n" +
                    "Anything else and the dealer will eject you from the table \n");

                string respone = Console.ReadLine();
                
                
                switch (respone.ToUpper())
                {
                    case "HIT":
                        this.player.Hand.Add(deck[0]);
                        this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);
                        break;
                    case "STAND":
                        gameLoop = false;
                        break;
                    default:
                        System.Environment.Exit(1);
                        break;
                }
                if (scoreCalc(this.player.Hand) > 21) 
                { 
                    gameLoop = false;
                    Console.Clear();
                    print(player.Hand);
                    Console.WriteLine("you when bust with a score: "+scoreCalc(player.Hand));
                    Console.ReadLine();
                    this.player.Isbust = true;
                }
            }
            if (!this.player.Isbust) {
            gameLoop = true;
            }
            
            this.dealer.Hand.Add(deck[0]);
            this.deck.Remove(this.dealer.Hand[this.dealer.Hand.Count - 1]);

            while (gameLoop)
            {
                print (this.dealer.Hand);

                if (this.dealer.Dealerturn(scoreCalc(this.dealer.Hand)))
                {
                    this.dealer.Hand.Add(deck[0]);
                    this.deck.Remove(this.dealer.Hand[this.dealer.Hand.Count - 1]);

                    if (scoreCalc(this.dealer.Hand) > 21)
                    {
                        this.dealer.Isbust = true;
                        break;
                    }
                }
                else {
                    gameLoop = false;
                    Console.Clear();
                    print(dealer.Hand);
                    Console.ReadLine ();
                }

            }

            if (((scoreCalc(this.player.Hand) > scoreCalc(this.dealer.Hand)) && !this.player.Isbust) && !this.dealer.Isbust)
            {
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("player wins on a score of " + scoreCalc(this.player.Hand));
                Console.ReadLine();
            }
            else if (((scoreCalc(this.player.Hand) < scoreCalc(this.dealer.Hand)) && !this.player.Isbust) && !this.dealer.Isbust)
            {
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("dealer wins on a score of " + scoreCalc(dealer.Hand));
                Console.ReadLine();
            }
            else if (this.player.Isbust && !this.dealer.Isbust)
            {
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("Dealer wins on player went bust");
                Console.ReadLine();
            } else if (!this.player.Isbust && this.dealer.Isbust) 
            {
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("player wins on dealer went bust");
                Console.ReadLine();
            } else if (((scoreCalc(this.player.Hand) == scoreCalc(this.dealer.Hand)) && !this.player.Isbust) && !this.dealer.Isbust)
            {
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("it a push");
                Console.ReadLine();
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
                        if (score + 11 <= 21)
                        { 
                            score += 11;
                        }

                        else { score += 1; }

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
