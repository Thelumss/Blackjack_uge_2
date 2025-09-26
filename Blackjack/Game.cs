namespace Blackjack
{
    class Game
    {

        // Game atributes
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
            //where the dealder and player get add to players for ease of som actions
            this.players.Add(dealer);
            this.players.Add(player);
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
                this.player.WagerAction();

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

                // dealers turn
                this.dealer.Dealerturn(this.deck);

                // Games out come
                GamesOutCome();


                // kicks the player out if the player has lost all of there money
                if (this.player.Money <= 0)
                {
                    this.gameLoop = false;
                    Console.Clear();
                    Console.WriteLine("" +
                        "You get kicked out of the casino for being a losser with no money!");
                }

            }
        }


        // To handle the results of the player and dealer and see who wins and losses and if it is a push
        public void GamesOutCome()
        {
            for (int i = 0; i < this.player.Hand.Count; i++)
            {
                Console.Clear();
                if (this.player.Hand.Count != 1)
                {
                    Console.WriteLine("the risults for hand number "+(i+1)+":");
                }

                // the player wins and dealer did not go bust
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
                
                // the dealer win and the player did not go bust
                else if (((this.player.scoreCalc(this.player.Hand[i]) < this.dealer.scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {

                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("dealer wins on a score of " + this.dealer.scoreCalc(this.dealer.Hand[0]));
                    Console.ReadLine();
                }

                // dealer win on player went bust
                else if (this.player.Isbust[i] && !this.dealer.Isbust[0])
                {


                    this.player.print(this.player.Hand[i]);
                    Console.WriteLine();
                    this.dealer.print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("Dealer wins on player went bust");
                    Console.ReadLine();
                }

                // the player win on the dealer went bust
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

                // dealer and player both went bust
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

                // dealer and player landed on the same score and did not go bust
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

        // gerates a new deck of cards for a new round 
        public List<Card> Newdeck()
        {
            List<Card> cards = new List<Card>();

            // this loop is for number of decks
            for (int d = 1; d <= 1; d++)
            {
                // this loop is for each suit
                for (int s = 1; s <= 4; s++)
                {
                    // this loop makes the value and face of the cards
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
