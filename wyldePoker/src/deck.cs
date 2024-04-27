using System;
using System.Security.Cryptography;

namespace wyldePoker {
   public class Deck {

      RandomNumberGenerator rnd = RandomNumberGenerator.Create();

      public int rndInt(int min, int max) {
         byte[] rbytes = new byte[4];
         rnd.GetBytes(rbytes);

         double dTmp = (double)BitConverter.ToUInt32(rbytes, 0) / 0xFFFFFFFF;

         return (( int )(dTmp*((max+1)-min)+min));
      }

      private int dealpos = 0;
      public Card[] cards = new Card[52];

      public Deck() { //constructor
         for (int i = 0;i<52;i++) {
            cards[i] = new Card(i);
         }
      }

      /// <summary>
      /// Shuffles the deck
      /// </summary>
      public void Shuffle() {

         int p1 = 0; int p2 = 0;
         Card card = new Card(0);
         Deck deck = new Deck();

         //shuffle:pick 2 random cards and swap their positions 1040 times
         for (int i = 0;i<1040;i++) {
            p1 = rndInt(0,51); p2 = rndInt(0,51);
            card = cards[p1];       //pull card1 out
            cards[p1] = cards[p2];  //put card2 where card1 was
            cards[p2] = card;       //put card1 where card2 was
         }

         //bridge shuffle
         for (int i = 0;i<26;i++) {
            deck.cards[i*2] = cards[i];
            deck.cards[i*2+1] = cards[26+i];
         }

         //table cut
         p1 = rndInt(0, 51);
         for (int i = 0;i<52;i++) {
            cards[i] = deck.cards[p1];
            p1++;
            if (p1>51) p1 = 0;
         }

         //random swap shuffle again
         for (int i = 0;i<1040;i++) {
            p1 = rndInt(0, 51); p2 = rndInt(0, 51);
            card = cards[p1];       //pull card1 out
            cards[p1] = cards[p2];  //put card2 where card1 was
            cards[p2] = card;       //put card1 where card2 was
         }

         //bridge shuffle
         for (int i = 0;i<26;i++) {
            deck.cards[i*2] = cards[i];
            deck.cards[i*2+1] = cards[26+i];
         }

         //table cut
         p1 = rndInt(0, 51);
         for (int i = 0;i<52;i++) {
            cards[i] = deck.cards[p1];
            p1++;
            if (p1>51) p1 = 0;
         }

         dealpos = 0;
      }

      /// <summary>
      /// Deals one card from top of deck
      /// </summary>
      /// <returns>Card object equal to cards[dealpos]</returns>
      public Card nextCard() {
         dealpos++;
         return cards[dealpos-1];
      }
   }
}

