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
        Player player = new Player(100);
        Dealer dealer = new Dealer(0);
        bool turnLoop = true;
        bool gameLoop = true;
        // sets up the game and as in the cards 
        public Game() {
            this.deck = Newdeck();
        }

        public void GameLoop()
        {

            while (gameLoop)
            {
                
                this.deck = Newdeck();

            Random rng = new Random();
            int n = this.deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = this.deck[k];
                this.deck[k] = this.deck[n];
                this.deck[n] = value;
            }
                this.player.ClearHand();
                this.dealer.ClearHand();
            
                this.player.Isbust = false;
                this.dealer.Isbust = false;

                this.player.Wager = 0;

                this.turnLoop = true;

                while (this.player.Wager == 0)
                {

                    Console.Clear();
                    Console.WriteLine("What about of Money will you wager of your total of "+this.player.Money);
                    try { 
                        this.player.Wager = int.Parse(Console.ReadLine());
                        if (this.player.Wager <= this.player.Money)
                        { 
                        this.player.Money -= this.player.Wager;
                        }else 
                        {
                            this.player.Wager = 0;
                            continue;
                        }

                    } catch { }
                }

                this.dealer.Hand.Add(this.deck[0]);
                this.deck.Remove(this.dealer.Hand[this.dealer.Hand.Count - 1]);
                
                this.player.Hand.Add(this.deck[0]);
                this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);
                
                this.dealer.Hand.Add(deck[0]);
                this.deck.Remove(this.dealer.Hand[this.dealer.Hand.Count - 1]);

                this.player.Hand.Add(this.deck[0]);
                this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);

            
            while (this.turnLoop)
            {
                PlayerTurn();
            }


            if (!this.player.Isbust) {
                this.turnLoop = true;
            }
            


            this.dealer.Hand.Add(deck[0]);
            this.deck.Remove(this.dealer.Hand[this.dealer.Hand.Count - 1]);
            
            while (this.turnLoop)
            {
                Dealerturn();
            }

            GamesOutCome();
                if (this.player.Money <= 0)
                {
                    gameLoop = false;
                    Console.Clear();
                    Console.WriteLine("" +
                        "You get kicked out of the casino for being a losser with no money!");
                }
   
            }
        }

        public void GamesOutCome()
        {
            if (((scoreCalc(this.player.Hand) > scoreCalc(this.dealer.Hand)) && !this.player.Isbust) && !this.dealer.Isbust)
            {
                if (scoreCalc(this.player.Hand)==21)
                {
                    double temp = 2.5;
                    this.player.Money += (float)(this.player.Wager*temp);
                }
                else
                {
                    this.player.Money += this.player.Wager * 2;
                }
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
            }
            else if (!this.player.Isbust && this.dealer.Isbust)
            {
                this.player.Money += this.player.Wager*2;
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("player wins on dealer went bust");
                Console.ReadLine();
            }
            else if (((scoreCalc(this.player.Hand) == scoreCalc(this.dealer.Hand)) && !this.player.Isbust) && !this.dealer.Isbust)
            {
                this.player.Money += this.player.Wager;
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine();
                print(this.dealer.Hand);
                Console.WriteLine();
                Console.WriteLine("it a push");
                Console.ReadLine();
            }
        }

        public void Dealerturn ()
        {
            print(this.dealer.Hand);

            if (this.dealer.Dealerturn(scoreCalc(this.dealer.Hand)))
            {

                if (scoreCalc(this.dealer.Hand) > 21)
                {
                    this.dealer.Isbust = true;
                }
            }
            else
            {
                this.turnLoop = false;
                Console.Clear();
                print(this.dealer.Hand);
                Console.ReadLine();
            }
        }
        public void PlayerTurn()
        {
            
            Console.Clear();

            print(this.player.Hand);
            int score = scoreCalc(this.player.Hand);

            Console.WriteLine("" +
                "score:" + score + "\n" +
                "you have this much: "+this.player.Money+" money beyon what you wagered\n");

            Console.WriteLine("dealers shown Card:");
            Console.WriteLine(this.dealer.Hand[0].Name + " of " + this.dealer.Hand[0].Suit);

            Console.WriteLine("\n" +
                "Type HIT to get a other card \n" +
                "Type STAND to be done getting cards");
            if ((this.player.Hand.Count == 2) && (this.player.Money>=this.player.Wager))
            {
                Console.WriteLine("type Double to double your wager and get only one card");

            }
            
            if (this.player.Hand.Count == 2 && this.player.Hand[0].Name.Equals(this.player.Hand[1].Name) && (this.player.Money >= this.player.Wager)) 
            {
                Console.WriteLine("type split to split your hand in to two hands");
            }

            if (this.dealer.Hand[0].Value ==0) 
            {
                Console.WriteLine("type insurance to bet that the dealer has natural blackjack");
            }
                Console.WriteLine("\n" +
                    "Anything else and the dealer will eject you from the table \n");

            string respone = Console.ReadLine();


            switch (respone.ToUpper())
            {
                case "HIT":
                    this.player.Hand.Add(this.deck[0]);
                    this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);
                    break;
                case "STAND":
                    this.turnLoop = false;
                    break;
                case "DOUBLE":
                    this.player.Money -= this.player.Wager;
                    this.player.Wager = this.player.Wager*2;
                    this.player.Hand.Add(this.deck[0]);
                    this.deck.Remove(this.player.Hand[this.player.Hand.Count - 1]);
                    this.turnLoop = false;
                    break;
                case "SPLIT":

                    break;
                case "INSURANCE":

                    break;
                default:
                    System.Environment.Exit(1);
                    break;
            }
            if (scoreCalc(this.player.Hand) > 21)
            {
                this.turnLoop = false;
                Console.Clear();
                print(this.player.Hand);
                Console.WriteLine("you when bust with a score: " + scoreCalc(this.player.Hand));
                Console.ReadLine();
                this.player.Isbust = true;
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

        public List<Card> Newdeck()
        {
            List<Card> cards = new List<Card>();
            for (int d = 1; d <= 1; d++)
            {
                for (int s = 1; s <= 4; s++)
                {

                    for (int v = 2; v <= 14; v++)
                    {
                        Card card = new Card(v, s, v);
                        cards.Add(card);
                    }
                }

            }
            return cards;
        }

    }
}
