namespace wyldePoker {
   public partial class Eval {
      #region /* Hand Eval Functions */

      public int eval(int[] cards) {
         switch (cards.Length) {
            case 5:
               return evaluate_5cards(cards[0], cards[1], cards[2], cards[3], cards[4]);
            case 6:
               return evaluate_6cards(cards[0], cards[1], cards[2], cards[3], cards[4], cards[5]);
            case 7:
               return evaluate_7cards(cards[0], cards[1], cards[2], cards[3], cards[4], cards[5], cards[6]);
            default:
               return 0;
         }
      }

      public int eval5(int[] cards) {
         return evaluate_5cards(cards[0], cards[1], cards[2], cards[3], cards[4]);
      }
      public int evaluate_5cards(int a, int b, int c, int d, int e) {
         int suit_hash = 0;

         suit_hash += SuitHasher[a]; // (2^((a & 0x3) * 3))
         suit_hash += SuitHasher[b]; // (2^((b & 0x3) * 3))
         suit_hash += SuitHasher[c]; // (2^((c & 0x3) * 3))
         suit_hash += SuitHasher[d]; // (2^((d & 0x3) * 3))
         suit_hash += SuitHasher[e]; // (2^((e & 0x3) * 3))

         if (suits[suit_hash]>0) {
            ushort[] suit_binary = new ushort[4];

            suit_binary[a & 0x3] |= RankBinary[a]; // (2^(a / 4))
            suit_binary[b & 0x3] |= RankBinary[b]; // (2^(b / 4))
            suit_binary[c & 0x3] |= RankBinary[c]; // (2^(c / 4))
            suit_binary[d & 0x3] |= RankBinary[d]; // (2^(d / 4))
            suit_binary[e & 0x3] |= RankBinary[e]; // (2^(e / 4))

            return flush[suit_binary[suits[suit_hash] - 1]];
         }

         byte[] quinary = new byte[13];

         quinary[(a >> 2)]++; //could just x/4, assume rshift is faster
         quinary[(b >> 2)]++; //could just x/4, assume rshift is faster
         quinary[(c >> 2)]++; //could just x/4, assume rshift is faster
         quinary[(d >> 2)]++; //could just x/4, assume rshift is faster
         quinary[(e >> 2)]++; //could just x/4, assume rshift is faster

         int hash = hash_quinary(quinary, 5);

         return noflush5[hash];
      }
      public int eval6(int[] cards) {
         return evaluate_6cards(cards[0], cards[1], cards[2], cards[3], cards[4], cards[5]);
      }
      public int evaluate_6cards(int a, int b, int c, int d, int e, int f) {
         int suit_hash = 0;

         suit_hash += SuitHasher[a]; // (2^((a & 0x3) * 3))
         suit_hash += SuitHasher[b]; // (2^((b & 0x3) * 3))
         suit_hash += SuitHasher[c]; // (2^((c & 0x3) * 3))
         suit_hash += SuitHasher[d]; // (2^((d & 0x3) * 3))
         suit_hash += SuitHasher[e]; // (2^((e & 0x3) * 3))
         suit_hash += SuitHasher[f]; // (2^((f & 0x3) * 3))

         if (suits[suit_hash] > 0) {
            int[] suit_binary = new int[4];

            suit_binary[a & 0x3] |= RankBinary[a]; // (2^(a / 4))
            suit_binary[b & 0x3] |= RankBinary[b]; // (2^(b / 4))
            suit_binary[c & 0x3] |= RankBinary[c]; // (2^(c / 4))
            suit_binary[d & 0x3] |= RankBinary[d]; // (2^(d / 4))
            suit_binary[e & 0x3] |= RankBinary[e]; // (2^(e / 4))
            suit_binary[f & 0x3] |= RankBinary[f]; // (2^(f / 4))

            return flush[suit_binary[suits[suit_hash] - 1]];
         }

         byte[] quinary = new byte[13];

         quinary[(a >> 2)]++;
         quinary[(b >> 2)]++;
         quinary[(c >> 2)]++;
         quinary[(d >> 2)]++;
         quinary[(e >> 2)]++;
         quinary[(f >> 2)]++;

         int hash = hash_quinary(quinary, 6);

         return noflush6[hash];
      }
      public int eval7(int[] cards) {
         return evaluate_7cards(cards[0], cards[1], cards[2], cards[3], cards[4], cards[5], cards[6]);
      }
      public int evaluate_7cards(int a, int b, int c, int d, int e, int f, int g) {
         int suit_hash = 0;

         suit_hash += SuitHasher[b]; // (2^((b & 0x3) * 3))
         suit_hash += SuitHasher[c]; // (2^((c & 0x3) * 3))
         suit_hash += SuitHasher[d]; // (2^((d & 0x3) * 3))
         suit_hash += SuitHasher[e]; // (2^((e & 0x3) * 3))
         suit_hash += SuitHasher[f]; // (2^((f & 0x3) * 3))
         suit_hash += SuitHasher[a]; // (2^((a & 0x3) * 3))
         suit_hash += SuitHasher[g]; // (2^((g & 0x3) * 3))

         if (suits[suit_hash] > 0) {
            int[] suit_binary = new int[4];

            suit_binary[a & 0x3] |= RankBinary[a]; // (2^(a / 4))
            suit_binary[b & 0x3] |= RankBinary[b]; // (2^(b / 4))
            suit_binary[c & 0x3] |= RankBinary[c]; // (2^(c / 4))
            suit_binary[d & 0x3] |= RankBinary[d]; // (2^(d / 4))
            suit_binary[e & 0x3] |= RankBinary[e]; // (2^(e / 4))
            suit_binary[f & 0x3] |= RankBinary[f]; // (2^(f / 4))
            suit_binary[g & 0x3] |= RankBinary[g]; // (2^(g / 4))

            return flush[suit_binary[suits[suit_hash] - 1]];
         }

         byte[] quinary = new byte[13];

         quinary[(a >> 2)]++;
         quinary[(b >> 2)]++;
         quinary[(c >> 2)]++;
         quinary[(d >> 2)]++;
         quinary[(e >> 2)]++;
         quinary[(f >> 2)]++;
         quinary[(g >> 2)]++;

         int hash = hash_quinary(quinary, 7);

         return noflush7[hash];
      }

      #endregion /* Hand Eval Functions */

      #region /* Rank String Descriptors */
      public enum rank_category {
         // FIVE_OF_A_KIND = 0, // Reserved
         STRAIGHT_FLUSH = 1,
         FOUR_OF_A_KIND,
         FULL_HOUSE,
         FLUSH,
         STRAIGHT,
         THREE_OF_A_KIND,
         TWO_PAIR,
         ONE_PAIR,
         HIGH_CARD
      };

      private static string[] rank_category_description = {
         "",
         "Straight Flush",
         "Quads",
         "Full House",
         "Flush",
         "Straight",
         "Trips",
         "Two Pair",
         "One Pair",
         "High Card",
      };

      private rank_category get_rank_category(int rank) {
         if (rank > 6185) return rank_category.HIGH_CARD;        // 1277 high card
         if (rank > 3325) return rank_category.ONE_PAIR;         // 2860 one pair
         if (rank > 2467) return rank_category.TWO_PAIR;         //  858 two pair
         if (rank > 1609) return rank_category.THREE_OF_A_KIND;  //  858 three-kind
         if (rank > 1599) return rank_category.STRAIGHT;         //   10 straights
         if (rank > 322) return rank_category.FLUSH;            // 1277 flushes
         if (rank > 166) return rank_category.FULL_HOUSE;       //  156 full house
         if (rank > 10) return rank_category.FOUR_OF_A_KIND;   //  156 four-kind
         return rank_category.STRAIGHT_FLUSH;                    //   10 straight-flushes
      }

      public string rankCatDesc(rank_category category) {
         return rank_category_description[( int )category];//short desc "Flush" "Straight" "Trips"
      }
      public string rankDesc(int rank)//long desc "Full House A/J" "K-High Straight" "T-High Flush"
      {
         return rank_description[rank, 1];
      }
      public string handDesc(int rank) //short hand representation "AA882" "5432A" "TTT74"
      {
         return rank_description[rank, 0];
      }
      public bool isFlush(int rank) {
         switch (get_rank_category(rank)) {
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