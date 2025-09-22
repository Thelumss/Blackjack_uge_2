using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        // proporties a Card
        private int name;
        private int suit;
        private int value;

        public Card(int name,int suit, int value)
        {
            this.name = name;
            this.value = value;
            this.suit = suit;
        }

        // value returner value af kortet i blackjack som er særligt for biled kort og ace
        public int Value {
            get 
            {
                if (value >= 10 && value != 14) { return 10; }
                else if (value == 14) { return 0; }else
                {
                    return value; 
                }
            }
        }

        // bruger tallet til at find dens navn
        public string Name { 
            get
            {
                switch (name) {
                    case 2:
                        return "2";
                    case 3:
                        return "3";
                    case 4:
                        return "4";
                    case 5:
                        return "5";
                    case 6:
                        return "6";
                    case 7:
                        return "7";
                    case 8:
                        return "8";
                    case 9:
                        return "9";
                    case 10:
                        return "10";
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    case 14:
                        return "Ace";
                }
                return null;
            }
        }

        // bruger int til at finde den culor
        public string Suit {
            get 
            {
                switch (suit)
                {
                    case 1:
                        return "Hearts";
                        
                    case 2:
                        return "Diamonds";
                    case 3:
                        return "Clubs";
                    case 4:
                        return "Spades";
                }
                return null;
            }
        }
    }
}
