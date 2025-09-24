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
        public Game()
        {
            this.deck = Newdeck();
        }

        public void GameLoop()
        {

            while (gameLoop)
            {


                // this sets up the game for evrey round so that the players and the dealer are ready for a new round and with a fresh deck 
                this.player.ClearHand();
                this.dealer.ClearHand();
                this.player.Wager.Clear();
                this.player.Isbust.Clear();

                List<Card> testc = new List<Card>();
                List<Card> testd = new List<Card>();
                

                this.player.Hand.Add(testc);
                this.dealer.Hand.Add(testd);
                this.player.Wager.Add(0);
                this.player.Isbust.Add(false);
                this.dealer.Isbust.Add(false);

                for (int i = 0; i < this.player.Isbust.Count; i++)
                {
                this.player.Isbust[i] = false;
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

                this.turnLoop = true;

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
                while (this.turnLoop)
                {
                    PlayerTurn();
                }

                turnLoop = true;

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
            for (int i = 0; i < this.player.Hand.Count; i++)
            {

                if (((scoreCalc(this.player.Hand[i]) > scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {
                    if (scoreCalc(this.player.Hand[i]) == 21)
                    {
                        double temp = 2.5;
                        this.player.Money += (float)(this.player.Wager[i] * temp);
                    }
                    else
                    {
                        this.player.Money += this.player.Wager[i] * 2;
                    }
                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine();
                    print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("player wins on a score of " + scoreCalc(this.player.Hand[i]));
                    Console.ReadLine();
                }
                else if (((scoreCalc(this.player.Hand[i]) < scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {
                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine();
                    print(dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("dealer wins on a score of " + scoreCalc(dealer.Hand[0]));
                    Console.ReadLine();
                }
                else if (this.player.Isbust[i] && !this.dealer.Isbust[0])
                {

                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine();
                    print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("Dealer wins on player went bust");
                    Console.ReadLine();
                }
                else if (!this.player.Isbust[i] && this.dealer.Isbust[0])
                {
                    this.player.Money += this.player.Wager[i] * 2;
                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine();
                    print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("player wins on dealer went bust");
                    Console.ReadLine();
                }
                else if (((scoreCalc(this.player.Hand[i]) == scoreCalc(this.dealer.Hand[0])) && !this.player.Isbust[i]) && !this.dealer.Isbust[0])
                {
                    this.player.Money += this.player.Wager[i];
                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine();
                    print(this.dealer.Hand[0]);
                    Console.WriteLine();
                    Console.WriteLine("it a push");
                    Console.ReadLine();
                }
            }
        }

        public void Dealerturn()
        {
            print(this.dealer.Hand[0]);

            if (this.dealer.Dealerturn(scoreCalc(this.dealer.Hand[0])))
            {

                this.dealer.Hand[0].Add(deck[0]);
                this.deck.Remove(this.dealer.Hand[0][this.dealer.Hand[0].Count - 1]);

                if (scoreCalc(this.dealer.Hand[0]) > 21)
                {
                    this.dealer.Isbust[0] = true;
                }
            }
            else
            {
                this.turnLoop = false;
                Console.Clear();
                print(this.dealer.Hand[0]);
                Console.ReadLine();
            }
        }
        public void PlayerTurn()
        {
            for (int i = 0; i < this.player.Hand.Count; i++)
            {
                if (this.player.Hand[i].Count < 2)
                {
                    for (int j = 0; j < this.player.Hand.Count; j++)
                    {
                        this.player.Hand[j].Add(this.deck[0]);
                        this.deck.Remove(this.player.Hand[j][this.player.Hand[j].Count - 1]);

                    }
                }
                Console.Clear();

                print(this.player.Hand[i]);
                int score = scoreCalc(this.player.Hand[i]);

                Console.WriteLine("" +
                    "score:" + score + "\n" +
                    "you have this much: " + this.player.Money + " money beyon what you wagered\n");

                Console.WriteLine("dealers shown Card:");
                Console.WriteLine(this.dealer.Hand[0][0].Name + " of " + this.dealer.Hand[0][0].Suit);

                Console.WriteLine("\n" +
                    "Type HIT to get a other card \n" +
                    "Type STAND to be done getting cards");
                if ((this.player.Hand.Count == 2) && (this.player.Money >= this.player.Wager[i]))
                {
                    Console.WriteLine("type Double to double your wager and get only one card");

                }

                this.player.Hand[0][0] = new Card(2,1,1);
                this.player.Hand[0][1] = new Card(2,2,1);

                if ((this.player.Hand[i].Count == 2) && (this.player.Hand[i][0].Name == this.player.Hand[i][1].Name) && (this.player.Money > this.player.Wager[i]))
                {
                    Console.WriteLine("type split to split your hand in to two hands");
                }

                if (this.dealer.Hand[0][0].Value == 0)
                {
                    Console.WriteLine("type insurance to bet that the dealer has natural blackjack");
                }
                Console.WriteLine("\n" +
                    "Anything else and the dealer will eject you from the table \n");

                string respone = Console.ReadLine();


                switch (respone.ToUpper())
                {
                    case "HIT":
                        this.player.Hand[i].Add(this.deck[0]);
                        this.deck.Remove(this.player.Hand[i][this.player.Hand[i].Count - 1]);
                        break;
                    case "STAND":
                        this.turnLoop = false;
                        break;
                    case "DOUBLE":
                        this.player.Money -= this.player.Wager[i];
                        this.player.Wager[i] = this.player.Wager[i] * 2;
                        this.player.Hand[i].Add(this.deck[0]);
                        this.deck.Remove(this.player.Hand[i][this.player.Hand[i].Count - 1]);
                        this.turnLoop = false;
                        break;
                    case "SPLIT":
                        this.player.Money -= this.player.Wager[i];
                        this.player.Wager.Add(this.player.Wager[i]);

                        List<Card> testcr = new List<Card>();
                        testcr.Add(this.player.Hand[i][0]);
                        this.player.Hand[i].Remove(this.player.Hand[i][0]);
                        this.player.Hand.Add(testcr);
                        this.player.Isbust.Add(false);

                        break;
                    case "INSURANCE":

                        break;
                    default:
                        System.Environment.Exit(1);
                        break;
                }
                if (scoreCalc(this.player.Hand[i]) > 21)
                {
                    this.turnLoop = false;
                    Console.Clear();
                    print(this.player.Hand[i]);
                    Console.WriteLine("you when bust with a score: " + scoreCalc(this.player.Hand[i]));
                    Console.ReadLine();
                    this.player.Isbust[i] = true;
                }
            }

        }
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
