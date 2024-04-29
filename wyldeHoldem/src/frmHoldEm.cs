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
      private int handcount = 0;

      public frmHoldEm() { // constructor
         
         InitializeComponent();

         pfc.AddFontFile(Application.StartupPath + "\\FiraCode-Regular.ttf");
         textBox1.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
         textBox1.Clear();

      }

      private void frmHoldEm_Load(object sender, System.EventArgs e) {
         //
      }

      private void BtnTest_Click(object sender, System.EventArgs e) {

         int PlayerCount = 6;       //# players to deal in
         int[] rank = new int[PlayerCount];                  //used to store hand rank
         Card[] hand = new Card[7]; //array of 7 card obj's that represent the hand to evaluate
         string sOut = "";          //interim output string, so we're not modifying a text box directly

         deck.Shuffle();            //pull rainbows out of unicorn anuses

         //grab table cards from deck, store in hand[2-6]
         sOut+= "[";
         for (int j = 0;j<5;j++) {
            sOut += deck.Cards[PlayerCount*2 + j]+" ";
            hand[2+j]=deck.Cards[PlayerCount*2 + j];
         }
         sOut = sOut.Trim() + "]\r\n";

         int count = 0; int win = 9999; bool split = false;
         for (int i = 0;i<PlayerCount;i++) {
            hand[0]=deck.Cards[i];
            hand[1]=deck.Cards[i+PlayerCount];
            rank[i]=eval.Eval(hand, 7);
            if (rank[i]==win) { count++; }
            if (rank[i]<win) { win = rank[i]; count=1; }
            rankcounter[( int )eval.rankCat(rank[i])]++;
         }
         if (count>1) { split = true; }

         for (int i = 0;i<PlayerCount;i++) {
            sOut += "[" + deck.Cards[i] + " " + deck.Cards[i+PlayerCount] + "] ";
            sOut += (eval.isFlush(rank[i]) ? "+" : " ") + eval.handNote(rank[i])+" => ";
            sOut += eval.handRank(rank[i],true) + ( (rank[i]==win) ? (split ? "  SPLIT" : " |>WIN<|") : "" );
            sOut += "\r\n";
         }

         handcount+=PlayerCount; //deal a hand to each player

         textBox1.Clear();
         for (int i = 0;i<10;i++) {
            textBox1.Text += (( double )rankcounter[i]/handcount).ToString("00.00% - ") + HandEvaluator.StrHandRankEnum[i,1] + "\r\n";
         }
         textBox1.Text+= handcount.ToString() + " - Total Hands\r\n";

         textBox1.Text += sOut;
      }

      private void btnChunk_Click(object sender, System.EventArgs e) {
         textBox1.Clear();
         for (int i = 0;i<1000;i++) {
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
