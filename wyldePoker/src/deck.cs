using System;
using System.Security.Cryptography;

namespace wyldePoker {
   public class Deck {

      RandomNumberGenerator rnd = RandomNumberGenerator.Create();

      /// <summary>
      /// Returns a more mathmatically sound random than Random.Next()
      /// </summary>
      /// <param name="max">int<=(2^32)-1</param>
      /// <param name="min">int>=0</param>
      /// <returns>int min<=x<=max </returns>
      public int rndInt(int max, int min=0) {
         byte[] rbytes = new byte[4];
         rnd.GetBytes(rbytes);
         //convert random bytes to uint32 then div by (2^32)-1 to convert to double [0,1)
         //do this instead of BitConverter.ToDouble to avoid negatives and constrain 0-1
         double dTmp = (double)BitConverter.ToUInt32(rbytes, 0) / 0xFFFFFFFF;

         return ((int)(dTmp * ((max+1) - min) + min));
      }

      private int dealpos = 0;
      public Card[] cards = new Card[52];

      public Deck() { //constructor
         for (int i = 0;i<52;i++) {
            cards[i] = new Card(i);
         }
      }

      ~Deck() { //finalizer
         rnd.Dispose();
      }

      /// <summary>
      /// Prints out entire deck into 4 rows and 13 columns
      /// </summary>
      /// <returns>String representation of entire deck</returns>
      public override string ToString() {
         string sOut = "";

         for (int i = 0; i<4; i++) {
            for (int j = 0; j<13; j++) {
               sOut += cards[i*13 + j].ToString() + " ";
            }
            sOut = sOut.Trim() + "\r\n";
         }
         sOut = sOut.Trim() + "\r\n";

         return sOut;
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

