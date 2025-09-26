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
        private string name;
        private string suit;
        private int value;

        public Card(int name,int suit, int value)
        { 
            this.value = value;


            // swich case uses the number to find the correct name
            switch (name)
            {
                case 2:
                    this.Name = "2";
                    break;
                case 3:
                    this.Name = "3";
                    break;
                case 4:
                    this.Name = "4";
                    break;
                case 5:
                    this.Name = "5";
                    break;
                case 6:
                    this.Name = "6";
                    break;
                case 7:
                    this.Name = "7";
                    break;
                case 8:
                    this.Name = "8";
                    break;
                case 9:
                    this.Name = "9";
                    break;
                case 10:
                    this.Name = "10";
                    break;
                case 11:
                    this.Name = "Jack";
                    break;
                case 12:
                    this.Name = "Queen";
                    break;
                case 13:
                    this.Name = "King";
                    break;
                case 14:
                    this.Name = "Ace";
                    break;
            }

            // swich case use number to find the correct suit 
            switch (suit)
            {
                case 1:
                    this.Suit = "Hearts";
                    break;
                case 2:
                    this.Suit = "Diamonds";
                    break;
                case 3:
                    this.Suit = "Clubs";
                    break;
                case 4:
                    this.Suit = "Spades";
                    break;
            }
        }

        // return the value of the card face cards and ace are speciel
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

        // gets the suit
        public string Suit { get => suit; set => suit = value; }
        // gets the name
        public string Name { get => name; set => name = value; }



    }
}
