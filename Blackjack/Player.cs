using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        // a list of the players hands
        private List<List<Card>> hand = new List<List<Card>>();
        // there money
        private double money = 0;
        // list of the players wagers per hand
        private List<double> wager = new List<double>();
        // list of if the player hand is bust
        private List<bool> isbust = new List<bool>();

        public Player(float money)
        {
            this.Money = money;
        }


        // clears the players hand
        public void ClearHand()
        {
            Hand.Clear();
        }


        // sets the player up for a new round
        public void NewRound()
        {
            this.ClearHand();
            this.Wager.Clear();
            this.Isbust.Clear();

            List<Card> startPlayerHand = new List<Card>();

            this.Hand.Add(startPlayerHand);
            this.Wager.Add(0);
            this.Isbust.Add(false);

        }

        // finds out how much the player is waging in this round
        public void WagerAction()
        {
            while (this.Wager[0] == 0)
            {

                Console.Clear();
                Console.WriteLine("What about of Money will you wager of your total of " + this.Money);
                try
                {
                    this.Wager[0] = (int.Parse(Console.ReadLine()));
                    if (this.Wager[0] <= this.Money)
                    {
                        this.Money -= this.Wager[0];
                    }
                    else
                    {
                        this.Wager[0] = 0;
                        continue;
                    }

                }
                catch { }
            }
        }

        // the players turn
        public void PlayerTurn(List<Card> deck, Dealer dealer)
        {
            for (int i = 0; i < this.Hand.Count; i++)
            {
                bool turnLoop = true;
                while (turnLoop)
                {
                    if (this.Hand[i].Count < 2)
                    {
                        for (int j = 0; j < this.Hand.Count; j++)
                        {
                            this.Hand[j].Add(deck[0]);
                            deck.Remove(this.Hand[j][this.Hand[j].Count - 1]);

                        }
                    }
                    Console.Clear();

                    print(this.Hand[i]);
                    int score = scoreCalc(this.Hand[i]);

                    Console.WriteLine("" +
                        "score:" + score + "\n" +
                        "you have this much: " + this.Money + " money beyon what you wagered\n");

                    Console.WriteLine("dealers shown Card:");
                    Console.WriteLine(dealer.Hand[0][0].Name + " of " + dealer.Hand[0][0].Suit);

                    Console.WriteLine("\n" +
                        "Type HIT to get a other card \n" +
                        "Type STAND to be done getting cards");
                    if ((this.Hand[i].Count == 2) && (this.Money >= this.Wager[i]))
                    {
                        Console.WriteLine("type Double to double your wager and get only one card");

                    }

                    if ((this.Hand[i].Count == 2) && (this.Hand[i][0].Value == this.Hand[i][1].Value) && (this.Money > this.Wager[i]))
                    {
                        Console.WriteLine("type split to split your hand in to two hands");
                    }

                    if (dealer.Hand[0][0].Value == 0)
                    {
                        Console.WriteLine("type insurance to bet that the dealer has natural blackjack");
                    }
                    Console.WriteLine("\n" +
                        "Anything else and the dealer will eject you from the table \n");

                    string respone = Console.ReadLine();


                    switch (respone.ToUpper())
                    {
                        case "HIT":
                            this.Hand[i].Add(deck[0]);
                            deck.Remove(this.Hand[i][this.Hand[i].Count - 1]);
                            break;
                        case "STAND":
                            turnLoop = false;
                            break;
                        case "DOUBLE":
                            this.Money -= this.Wager[i];
                            this.Wager[i] = this.Wager[i] * 2;
                            this.Hand[i].Add(deck[0]);
                            deck.Remove(this.Hand[i][this.Hand[i].Count - 1]);
                            turnLoop = false;
                            break;
                        case "SPLIT":
                            this.Money -= this.Wager[i];
                            this.Wager.Add(this.Wager[i]);

                            List<Card> newHand = new List<Card>();
                            newHand.Add(this.Hand[i][0]);
                            this.Hand[i].Remove(this.Hand[i][0]);
                            this.Hand.Add(newHand);
                            this.Isbust.Add(false);

                            break;
                        case "INSURANCE":
                            this.Money -= this.Wager[i] / 2;
                            if (scoreCalc(dealer.Hand[0]) == 21)
                            {
                                Console.WriteLine("The dealer has natrual 21");
                                this.Money += this.Wager[i];
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("The dealer dose not have natrual 21");
                                Console.ReadLine();
                            }
                            break;
                        default:
                            System.Environment.Exit(1);
                            break;
                    }
                    if (scoreCalc(this.Hand[i]) > 21)
                    {
                        turnLoop = false;
                        Console.Clear();
                        print(this.Hand[i]);
                        Console.WriteLine("you when bust with a score: " + scoreCalc(this.Hand[i]));
                        Console.ReadLine();
                        this.Isbust[i] = true;
                    }

                }
            }
        }

        // prints the players hand
        public void print(List<Card> hand)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i].Name + " of " + hand[i].Suit);
            }
        }

        // calculates the score of a hand
        public int scoreCalc(List<Card> cards)
        {
            int score = 0;
            List<Card> decks = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value != 0)
                {
                    score += cards[i].Value;

                }
                else
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


        public List<List<Card>> Hand { get => hand; set => hand = value; }
        public double Money { get => money; set => money = value; }
        public List<double> Wager { get => wager; set => wager = value; }
        public List<bool> Isbust { get => isbust; set => isbust = value; }
    }
}
