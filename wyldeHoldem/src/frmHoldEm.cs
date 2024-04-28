using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using wyldePoker;

namespace wyldeHoldem {
   public partial class frmHoldEm : Form {

      // private class wide declarations
      private Deck deck = new Deck();
      private HandEvaluator eval = new HandEvaluator();
      private PrivateFontCollection pfc = new PrivateFontCollection();
      //chart stuff
      private int[] rankcounter = new int[10];
      private static string[] x = { "StrFl", "Quad", "FHse", "Flsh", "Str", "Trip", "2 Pr", "Pair", "HC" };
      private int handcount =0;

      public frmHoldEm() { // constructor
         
         InitializeComponent();

         pfc.AddFontFile(Application.StartupPath + "\\ComicMono.ttf");
         textBox1.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
         textBox1.Clear();

      }

      private void frmHoldEm_Load(object sender, System.EventArgs e) {
         //
      }

      private void BtnTest_Click(object sender, System.EventArgs e) {

         int PlayerCount = 6;       //# players to deal in
         int rank;                  //used to store hand rank
         Card[] hand = new Card[7]; //array of 7 card obj's that represent the hand to evaluate
         string sOut = "";          //interim output string, so we're not modifying a text box directly

         deck.Shuffle();            //pull rainbows out of unicorn anuses

         //grab table cards from deck, store in hand[2-6]
         sOut+= "[";
         for (int j = 0;j<5;j++) {
            sOut += deck.cards[PlayerCount*2 + j]+" ";
            hand[2+j]=deck.cards[PlayerCount*2 + j];
         }
         sOut = sOut.Trim() + "]\r\n";

         //build 7 card hand from each players hole cards and the table cards
         for (int i = 0;i<PlayerCount;i++) {
            hand[0]=deck.cards[i];
            hand[1]=deck.cards[i+PlayerCount];
            sOut += "[" + hand[0] + " " + hand[1] + "] ";
            rank = eval.Eval(hand, 7);
            sOut += "<"+eval.handNote(rank)+"> "+eval.handRank(rank)+"\r\n";

            //int handrank = ( int )eval.rankCat(rank)-1;
            rankcounter[( int )eval.rankCat(rank)]++;
         }

         handcount+=PlayerCount; //deal a hand to each player

         textBox1.Clear();
         for (int i = 0;i<10;i++) {
            textBox1.Text += (rankcounter[i].ToString("0 (") + (( double )rankcounter[i]/handcount).ToString("0.####%) - ") + HandEvaluator.strHandRankEnum[i] + "\r\n");
         }
         textBox1.Text+= handcount.ToString() + " - Total Hands\r\n";


         textBox1.Text += sOut;

      }

      private void btnChunk_Click(object sender, System.EventArgs e) {
         textBox1.Clear();
         for (int i = 0;i<100000;i++) {
            BtnTest_Click(sender, e);
            this.Update();
         }
      }

      private void timer1_Tick(object sender, EventArgs e) {
         BtnTest_Click(sender, e);
      }

      private void checkBox1_CheckedChanged(object sender, EventArgs e) {
         timer1.Enabled= checkBox1.Checked;
      }
   }
}
