namespace Blackjack
{
    internal class Game
    {

        List<Card> deck = new List<Card>();
        List<Player> players = new List<Player>();
        Player player = new Player(100);
        Dealer dealer = new Dealer(0);
        bool gameLoop = true;

        // sets up the game and as in the cards 
        public Game()
        {
            this.deck = Newdeck();
        }

        public void GameLoop()
        {
            this.players.Add(player);
            this.players.Add(dealer);
            while (gameLoop)
            {
                // this sets up the game for evrey round so that the players and the dealer are ready for a new round and with a fresh deck 
                for (int i = 0; i < this.players.Count; i++)
                {
                    this.players[i].NewRound();
                }

                this.deck = Newdeck();


                // this segment is just the quikly suffle the deck
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

                // the betting segment
                while (this.player.Wager[0] == 0)
                {

                    Console.Clear();
                    Console.WriteLine("What about of Money will you wager of your total of " + this.player.Money);
                    try
                    {
                        this.player.Wager[0] = (int.Parse(Console.ReadLine()));
                        if (this.player.Wager[0] <= this.player.Money)
                        {
                            this.player.Money -= this.player.Wager[0];
                        }
                        else
                        {
                            this.player.Wager[0] = 0;
                            continue;
                        }

                    }
                    catch { }
                }

                // these work with taking the top card of the deck and adding to the hand and then removeing that specific entry from the list of the deck
                this.dealer.Hand[0].Add(this.deck[0]);
                this.deck.Remove(this.dealer.Hand[0][this.dealer.Hand[0].Count - 1]);

                this.player.Hand[0].Add(this.deck[0]);
                this.deck.Remove(this.player.Hand[0][this.player.Hand.Count - 1]);

                this.dealer.Hand[0].Add(deck[0]);
                this.deck.Remove(this.dealer.Hand[0][this.dealer.Hand[0].Count - 1]);

                this.player.Hand[0].Add(this.deck[0]);
                this.deck.Remove(this.player.Hand[0][this.player.Hand[0].Count - 1]);

                // the users turn
                this.player.PlayerTurn(this.deck, this.dealer);

                this.dealer.Dealerturn(this.deck);

                GamesOutCome();

                if (this.player.Money <= 0)
                {
                    this.gameLoop = false;
                    Console.Clear();
                    Console.WriteLine("" +
                        "You get kicked out of the casino for being a losser with no money!");
                }

            }
        }

        public void GamesOutCome()
        {
            for (int i = 0; i < this.player.Hand.Count; i++)
            {
                Console.Clear();
                if (this.player.Hand.Count != 1)
                {
                    Console.WriteLine("the risults for hand number "+i+1+":");
                }

                if (((this.player.scoreCalc(this.player.Hand[i]) > this.dealer.scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {
                    // extra mony if player gets natural blackjack
                    if (this.player.scoreCalc(this.player.Hand[i]) == 21 && this.player.Hand[i].Count ==2)
                    {
                        double natrualBlackJackBonus = 2.5;
                        this.player.Money += (float)(this.player.Wager[i] * natrualBlackJackBonus);
                    }
                    else
                    {
                        this.player.Money += this.player.Wager[i] * 2;
                    }

                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("player wins on a score of " + this.player.scoreCalc(this.player.Hand[i]));
                    Console.ReadLine();
                }
                else if (((this.player.scoreCalc(this.player.Hand[i]) < this.dealer.scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {

                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("dealer wins on a score of " + this.dealer.scoreCalc(this.dealer.Hand[0]));
                    Console.ReadLine();
                }
                else if (this.player.Isbust[i] && !this.dealer.Isbust[0])
                {


                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("Dealer wins on player went bust");
                    Console.ReadLine();
                }
                else if (!this.player.Isbust[i] && this.dealer.Isbust[0])
                {
                    this.player.Money += this.player.Wager[i] * 2;

                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("player wins on dealer went bust");
                    Console.ReadLine();
                }
                else if (this.player.Isbust[i] && this.dealer.Isbust[0])
                {
                    this.player.Money += this.player.Wager[i];

                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("it a push both went bust");
                    Console.ReadLine();
                }
                else if (((this.player.scoreCalc(this.player.Hand[i]) == this.dealer.scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {
                    this.player.Money += this.player.Wager[i];
                    
                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("it a push");
                    Console.ReadLine();
                }
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
