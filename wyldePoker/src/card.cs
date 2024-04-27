namespace wyldePoker {
   public class Card {
      //strCard[53]
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
         "Ac","Ad","Ah","As",
         "--"
      };

      private int id = 0;

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
               id = 53; break;
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
               id += 53; break;
         }
      }

      /// <summary>
      /// ToString override
      /// </summary>
      /// <returns>"Ah" "Ks" "5d" "3c"</returns>
      public override string ToString() { return strCard[id]; }

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
}
