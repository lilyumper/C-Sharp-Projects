using System;
using System.Collections.Generic;
namespace deck_of_cards
{
    public class Card {
        public string[] stringVal = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        public string[] suit = {"Clubs", "Spades", "Hearts", "Diamonds"};
    }
    public class Deck:Card {
        public List<string> cards = new List<string>{};
        public Random rand = new Random();
        public void cardCreate() {
            for ( int i = 0; i < this.suit.Length; i++) {
                for (int j = 0; j < this.stringVal.Length; j++) {
                    this.cards.Add(this.suit[i] + " " + this.stringVal[j]);
                }
            }
        }
        public string Deal() {
            // cardCreate();
            string card = this.cards[this.cards.Count-1];
            this.cards.RemoveAt(this.cards.Count-1);
            return card;
        }
        public void Shuffle(){
            for(int i = 0; i < this.cards.Count; i++){
                int index = rand.Next(0,this.cards.Count - 1);
                string temp = this.cards[i];
                this.cards[i] = this.cards[index];
                this.cards[index] = temp;
            }
        }
        public void Reset(){
            cardCreate();
        }
    }
    public class Player {
        public string name;
        public List<string> Hand = new List<string>{};
        public string Draw(List<string> a) {
            this.Hand.Add(a[a.Count - 1]);
            Console.WriteLine(a[a.Count - 1]);
            return a[a.Count - 1];
        }
        public string Discard(string card){
            if(this.Hand.Contains(card)){
                this.Hand.Remove(card);
                return "removed";
            }
            else {
                return $"You don't have {card}";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Deck cardDeck = new Deck();
            Player Tomas = new Player();
            cardDeck.cardCreate();
            cardDeck.Shuffle();
            Tomas.Draw(cardDeck.cards);
            Console.WriteLine(Tomas.Discard("Spades 4"));
        }
    }
}