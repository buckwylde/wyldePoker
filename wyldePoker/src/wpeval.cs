namespace wyldePoker {

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

         /* The big refactor
          * Condensed the three evaluate5,6, & 7 functions into one
          * Condensed param list from 5,6, or 7 ints from those functions
          * into an array of cards and count. This allowed for iterative
          * for loops to simplify code instead of chunks of assignments
          * for 5,6, or 7 ints.
          */

         if (cards.Length<count) return 0; // didn't get enough cards for requested eval
         if (count < 5) return 0; //can't eval less than 5 cards
         if (count > 7) count = 7; //limit to 7 cards for eval
         
         int suit_hash = 0;
         for(int i = 0;i<count;i++) // check for flush
            suit_hash+=SuitHasher[cards[i].ID];

         if (suits[suit_hash] > 0) {        // if flush found, look up rank in flush table
            int[] suit_binary = new int[4]; //we use the lower 13 bits as a bit field for the 13 ranks
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

      public static string[] strHandRankEnum = {
         "Royal Flush",
         "Straight Flush",
         "Quads",
         "Full House",
         "Flush",
         "Straight",
         "Trips",
         "Two Pair",
         "Pair",
         "High Card",
      };

      /// <summary>
      /// Rank only string descriptor
      /// </summary>
      /// <param name="rank">Hand rank to lookup in table</param>
      /// <returns>"Flush" "Straight" "Trips"</returns>
      public string handRank(int rank) {
         return strHandRankEnum[( int )rankCat(rank)]; 
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