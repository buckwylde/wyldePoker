using System;

namespace wyldePoker {
   public class Deck {

      private Random rnd = new Random();

      public int rndCard(int min = 0, int max = 51) {
         double dTmp = rnd.NextDouble();
         return (( int )(dTmp*((max+1)-min)+min));
      }

      private int dealpos = 0;
      public Card[] cards = new Card[52];

      public Deck() {
         for (int i = 0;i<52;i++) {
            cards[i] = new Card(i);
         }
      }

      public void Shuffle() {

         int pick1 = 0; int pick2 = 0;
         Card card = new Card(0);
         Deck deck = new Deck();

         //shuffle-pick 2 random cards and swap their positions 250 times
         for (int i = 0;i<250;i++) {
            pick1 = rndCard(); pick2 = rndCard();
            card = cards[pick1];
            cards[pick1] = cards[pick2];
            cards[pick2] = card;
         }

         //cut-pick random position, all cards > position go to top of deck
         //    all cards <= position go to bottom of deck
         pick1 = rndCard();
         for (int i = 0;i<52;i++) {
            deck.cards[i] = cards[pick1];
            pick1++;
            if (pick1>51) pick1 = 0;
         }

         //shuffle-pick 2 random cards and swap their positions 250 times
         for (int i = 0;i<250;i++) {
            pick1 = rndCard(); pick2 = rndCard();
            card = cards[pick1];
            cards[pick1] = cards[pick2];
            cards[pick2] = card;
         }

         //cut
         pick1 = rndCard();
         for (int i = 0;i<13;i++) {
            for (int j = 0;j<4;j++) {
               cards[i*4+j] = deck.cards[j*13+i];
               pick1++;
               if (pick1>51) pick1 = 0;
            }
         }
      }

      public Card nextCard() {
         dealpos++;
         return cards[dealpos-1];
      }
   }
}

