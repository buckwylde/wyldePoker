using System;

namespace wyldePoker {
   
   /// <summary>
   /// Random number generator using System.Security.Cryptography
   /// for random byte generation instead of System.Random
   /// </summary>
   public class cryptoRNG {
      System.Security.Cryptography.RandomNumberGenerator rnd;
   
      //constructor
      public cryptoRNG() { rnd = System.Security.Cryptography.RandomNumberGenerator.Create(); }
      //destructor
      ~cryptoRNG() { rnd.Dispose(); }

      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public double getDbl(double max = 1.0, double min = 0.0) {
         byte[] rbytes = new byte[8];
         rnd.GetBytes(rbytes);
         return (max-min)*(( double )BitConverter.ToUInt64(rbytes, 0) / 0xFFFFFFFFFFFFFFFF) + min;
      }

      /* Everything else calls getDbl and converts to whatever it needs */
      /// <summary>
      /// Returns a string of <paramref name="len"/> length composed of random characters from <paramref name="allowChar"/>
      /// </summary>
      /// <param name="len">Length of return string</param>
      /// <param name="allowChar">String of allowable characters for return string</param>
      /// <returns></returns>
      public string getString(int len, string allowChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?,.;:[]_+-=") {
         string sTmp = string.Empty;
         for(int i = 0;i<len;i++) {
            sTmp += allowChar[getUInt8(( byte )(allowChar.Length - 1))];
         }
         return sTmp;
      }
      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public float getSgl(float max = 1, float min = 0) {
         return (float)getDbl(max, min);
      }
      // UInt functions 8/16/32/64
      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public byte getUInt8(byte max = 255, byte min = 0) {
         return (( byte )(getDbl() * ((max+1) - min) + min));
      }
      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public ushort getUInt16(ushort max = 65535, ushort min = 0) {
         return (( ushort )(getDbl() * ((max+1) - min) + min));
      }
      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public uint getUInt32(uint max = System.UInt32.MaxValue, uint min = 0) {
         return (( uint )(getDbl() * ((max+1) - min) + min));
      }
      /// <summary>
      /// Returns a cryptographically sound random number, superior in randomness to System.Random
      /// </summary>
      /// <param name="max"></param>
      /// <param name="min"></param>
      /// <returns>Value of return type in range [<paramref name="min"/>, <paramref name="max"/>]</returns>
      public ulong getUInt64(ulong max = System.Int64.MaxValue, ulong min = 0) {
         return (( ulong )(getDbl() * ((max+1) - min) + min));
      }
   }

   public class Card {
      //strCard[52]
      private static string[] strCard = {
         "2c","2d","2h","2s",
         "3c","3d","3h","3s",
         "4c","4d","4h","4s",
         "5c","5d","5h","5s",
         "6c","6d","6h","6s",
         "7c","7d","7h","7s",
         "8c","8d","8h","8s",
         "9c","9d","9h","9s",
         "Tc","Td","Th","Ts",
         "Jc","Jd","Jh","Js",
         "Qc","Qd","Qh","Qs",
         "Kc","Kd","Kh","Ks",
         "Ac","Ad","Ah","As"
      };

      private int id = 0; // only way to set id is through constructors

      //constructors
      public Card(int x) { id = x; }
      public Card(string name) {
         id = 0;
         switch (name[1]) {
            case 'C':
            case 'c':
               id = 0; break;//not really needed, kept in for completion
            case 'D':
            case 'd':
               id = 1; break;
            case 'H':
            case 'h':
               id = 2; break;
            case 'S':
            case 's':
               id = 3; break;
            default:
               id = 255; break;//suit char not recognized, set to unknown
         }

         switch (name[0]) {
            case '2':
               id += 0; break;//not really needed, kept for completion
            case '3':
               id += 4; break;
            case '4':
               id += 8; break;
            case '5':
               id += 12; break;
            case '6':
               id += 16; break;
            case '7':
               id += 20; break;
            case '8':
               id += 24; break;
            case '9':
               id += 28; break;
            case 'T':
            case 't':
               id += 32; break;
            case 'J':
            case 'j':
               id += 36; break;
            case 'Q':
            case 'q':
               id += 40; break;
            case 'K':
            case 'k':
               id += 44; break;
            case 'A':
            case 'a':
               id += 48; break;
            default:
               id = 255; break;
         }
      }

      /// <summary>
      /// ToString override
      /// </summary>
      /// <returns>"Ah" "Ks" "5d" "3c"</returns>
      public override string ToString() {
         if (id<52) return strCard[id];
         return "--";
      }

      /// <summary>
      /// Readonly property for the int card ID
      /// </summary>
      public int ID { get => id; }

      /// <summary>
      /// Returns int 0-3 for card suit, c,d,h,s 
      /// </summary>
      public int Suit { get => id & 0x3; }

      /// <summary>
      /// Returns int 0-12 for card rank, 2-A
      /// </summary>
      public int Rank { get => id / 4; }
   }

   public class Deck {

      private int dealpos = 0;
      private Card[] cards = new Card[52];
      private readonly cryptoRNG rng = new cryptoRNG();

      public Card[] Cards { get => cards; set => cards=value; }

      public Deck() { //constructor
         for (int i = 0;i<52;i++) {
            Cards[i] = new Card(i);
         }
      }

      /// <summary>
      /// Prints out entire deck into 4 rows and 13 columns
      /// </summary>
      /// <returns>String representation of entire deck</returns>
      public override string ToString() {
         string sOut = "";

         for (int i = 0;i<4;i++) {
            for (int j = 0;j<13;j++) {
               sOut += Cards[i*13 + j].ToString() + " ";
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

         uint p1 = 0; uint p2 = 0;
         Card card = new Card(0);
         Deck deck = new Deck();

         //shuffle:pick 2 random cards and swap their positions
         for (int i = 0;i<78;i++) {
            p1 = rng.getUInt32(51); p2 = rng.getUInt32(51);
            card = Cards[p1];       //pull card1 out
            Cards[p1] = Cards[p2];  //put card2 where card1 was
            Cards[p2] = card;       //put card1 where card2 was
         }

         //bridge shuffle: result goes into local deck obj
         for (int i = 0;i<26;i++) {
            deck.Cards[i*2] = Cards[i];
            deck.Cards[i*2+1] = Cards[26+i];
         }

         //shuffle:pick 2 random cards and swap their positions
         for (int i = 0;i<78;i++) {
            p1 = rng.getUInt32(51); p2 = rng.getUInt32(51);
            card = deck.Cards[p1];       //pull card1 out
            deck.Cards[p1] = deck.Cards[p2];  //put card2 where card1 was
            deck.Cards[p2] = card;       //put card1 where card2 was
         }

         //table cut: result goes into class level deck obj
         p1 = rng.getUInt32(51);
         for (int i = 0;i<52;i++) {
            Cards[i] = deck.Cards[p1];
            p1++;
            if (p1>51) p1 = 0;
         }

         /*
         //random swap shuffle again
         for (int i = 0;i<1040;i++) {
            p1 = rng.getUInt32(51); p2 = rng.getUInt32(51);
            card = Cards[p1];       //pull card1 out
            Cards[p1] = Cards[p2];  //put card2 where card1 was
            Cards[p2] = card;       //put card1 where card2 was
         }

         //bridge shuffle
         for (int i = 0;i<26;i++) {
            deck.Cards[i*2] = Cards[i];
            deck.Cards[i*2+1] = Cards[26+i];
         }
         
         //table cut
         p1 = rng.getUInt32(51);
         for (int i = 0;i<52;i++) {
            Cards[i] = deck.Cards[p1];
            p1++;
            if (p1>51) p1 = 0;
         }
         */
         dealpos = 0;
      }

      /// <summary>
      /// Deals one card from top of deck
      /// </summary>
      /// <returns>Card object equal to cards[dealpos]</returns>
      public Card nextCard() {
         if(dealpos<52) dealpos++;
         return Cards[dealpos-1];
      }
   }

   public partial class HandEvaluator {

      //pure math black magic - Voldemort level
      private int hash_quinary(byte[] q, int k) {

         int sum = 0;
         const int len = 13;

         for (int i = 0;i < len;i++) {       //loops thru all card ranks 0-12
            sum += dp[q[i], len - i - 1, k]; //dp[how many cards of rank i we have,12-i,#cards being eval'd]

            //statements below provide for an early exit from the loop if we have found all k cards
            //left over from the C code, probably in an effort for as much speed as possible
            //left it in cuz no reason to slow down on purpose...
            k -= q[i];
            if (k <= 0)
               break;
         }
         return sum;
      }


      /// <summary>
      /// The hand evaluation function
      /// </summary>
      /// <param name="cards">Function starts with index 0</param>
      /// <param name="count">5-7, number of cards from array to eval</param>
      /// <returns>int 1-7462, lower value is higher rank, 1=Royal Flush</returns>
      public int Eval(Card[] cards, int count=7) {

         if (cards.Length<count) return 0; // didn't get enough cards for requested eval
         if (count < 5) return 0;          // can't eval less than 5 cards
         if (count > 7) count = 7;         // limit to 7 cards for eval
         
         int suit_hash = 0;
         for(int i = 0;i<count;i++) // check for flush
            suit_hash+=SuitHasher[cards[i].ID];

         if (suits[suit_hash] > 0) {        // if flush found, look up rank in flush table
            int[] suit_binary = new int[4]; // we use the lower 13 bits as a bit field for the 13 ranks
            for(int i = 0;i<count;i++)      // grab 2^(cardrank) from a table to avoid doing the math
               suit_binary[cards[i].Suit] |= RankBinary[cards[i].ID];
            return flush[suit_binary[suits[suit_hash] - 1]];
         }

         // no flushes, build quinary (base5) hash table
         byte[] quinary = new byte[13]; //keeps track of how many of each rank (2-A) we have
         for (int i = 0;i<count;i++) quinary[(cards[i].Rank)]++;
         
         // lookup rank in appropriate hash table based on # cards
         if (count>=7) { return noflush7[hash_quinary(quinary, 7)]; }
         if (count>=6) { return noflush6[hash_quinary(quinary, 6)]; }
         return noflush5[hash_quinary(quinary, 5)];
      }

      /*** Rank String Descriptors ***/
      #region /*******************************/

      public enum rank_category {
         ROYAL = 0, // Reserved
         STRAIGHT_FLUSH = 1,
         QUADS,
         FULL_HOUSE,
         FLUSH,
         STRAIGHT,
         TRIPS,
         TWO_PAIR,
         ONE_PAIR,
         HIGH_CARD
      };

      public rank_category rankCat(int rank) {
         if (rank > 6185) return rank_category.HIGH_CARD;   // 1277 high card
         if (rank > 3325) return rank_category.ONE_PAIR;    // 2860 one pair
         if (rank > 2467) return rank_category.TWO_PAIR;    //  858 two pair
         if (rank > 1609) return rank_category.TRIPS;       //  858 three-kind
         if (rank > 1599) return rank_category.STRAIGHT;    //   10 straights
         if (rank > 322) return rank_category.FLUSH;        // 1277 flushes
         if (rank > 166) return rank_category.FULL_HOUSE;   //  156 full house
         if (rank > 10) return rank_category.QUADS;         //  156 four-kind
         if (rank > 1) return rank_category.STRAIGHT_FLUSH; //    9 straight-flushes
         return rank_category.ROYAL;                        //    1 royal flush
      }

      private static string[,] strHandRankEnum = {
         {"Royal Flush", "RF" },
         {"Straight Flush", "SF" },
         {"Quads", "4K" },
         {"Full House", "FH" },
         {"Flush", "FL" },
         {"Straight", "ST" },
         {"Trips", "3K" },
         {"Two Pair", "2P" },
         {"Pair", "PR" },
         {"High Card", "HC" }
      };

      public static string[,] StrHandRankEnum { get => strHandRankEnum; }// set => strHandRankEnum=value; }

      /// <summary>
      /// Rank only string descriptor
      /// </summary>
      /// <param name="rank">Hand rank to lookup in table</param>
      /// <returns>"Flush" "Straight" "Trips"</returns>
      public string handRank(int rank, bool abbr = false) {
         return StrHandRankEnum[( int )rankCat(rank),abbr?1:0]; 
      }

      /// <summary>
      /// Hand full string descriptor
      /// </summary>
      /// <param name="rank">Hand rank to lookup in table</param>
      /// <returns>"[AJT74] Flush (Ace High)" "[5432A] Straight (5 High)" "[TTT74] Trips (10's)"</returns>
      public string handDesc(int rank) {
         return "["+rank_description[rank, 0]+"] "+handRank(rank)+" ("+rank_description[rank, 1]+")";
      }

      /// <summary>
      /// 'Short-hand' hand representation
      /// </summary>
      /// <param name="rank">Hand rank to lookup in table</param>
      /// <returns>"AJT74" "5432A" "TTT74"</returns>
      public string handNote(int rank) {
         return rank_description[rank, 0];
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="rank">hand rank to check</param>
      /// <returns>returns true/false for flush</returns>
      public bool isFlush(int rank) {
         switch (rankCat(rank)) {
            case rank_category.STRAIGHT_FLUSH:
            case rank_category.FLUSH:
               return true;
            default:
               return false;
         }
      }

      #endregion /* Rank String Descriptors */
   }

}