using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

using wyldePoker;

namespace wyldeHoldem {
   public partial class frmHoldEm : Form {

      // private class wide declarations
      private Deck deck = new Deck();
      private HandEvaluator eval = new HandEvaluator();
      private PrivateFontCollection pfc = new PrivateFontCollection();
      
      // stat stuff
      private int[] rankcounter = new int[10];
      private int handcount = 0;

      public frmHoldEm() { // constructor
         
         InitializeComponent();

         string fnFont = Application.StartupPath + "\\FiraCode-Regular.ttf";
         if (System.IO.File.Exists(fnFont)) {
            pfc.AddFontFile(fnFont);
            textBox1.Font = new Font(pfc.Families[0], 10, FontStyle.Regular);
         }
         textBox1.Clear();
      }

      private void frmHoldEm_Load(object sender, System.EventArgs e) {
         //
      }

      private void BtnTest_Click(object sender, System.EventArgs e) {

         int PlayerCount = 6;       //# players to deal in
         int[] rank = new int[PlayerCount]; //used to store hand rank
         Hand[] hands = new Hand[PlayerCount]; //array of 7 hand obj's that represent the hand to evaluate
         string sOut = "";          //interim output string, so we're not modifying a text box directly
         Card[] table = new Card[5];
         deck.Shuffle();            //pull rainbows out of unicorn anuses

         //grab table cards from deck, store in hand[2-6]
         sOut+= "[";
         for (int j = 0;j<5;j++) {
            int offset = 0; //handles burning a card before flop, turn and river
            switch (j) {
               case 0://flop
               case 1://flop
               case 2://flop
                  offset = 1; break;
               case 3://turn
                  offset = 2; break;
               case 4://river
                  offset = 3; break;
            }
            table[j]=deck.Cards[PlayerCount*2 + j + offset];
            sOut +=  table[j]+" ";
         }
         sOut = sOut.Trim() + "]\r\n";

         int count = 0; int win = 9999; bool split = false;
         for (int i = 0;i<PlayerCount;i++) {
            hands[i] = new Hand(table);
            hands[i].Add(deck.Cards[i]);
            hands[i].Add(deck.Cards[i+PlayerCount]);
            rank[i]=hands[i].Evaluate(); //eval.Eval(hand, 7);
            if (rank[i]==win) { count++; }
            if (rank[i]<win) { win = rank[i]; count=1; }
            rankcounter[( int )eval.rankCat(rank[i])]++;
         }
         if (count>1) { split = true; }

         for (int i = 0;i<PlayerCount;i++) {
            sOut += "[" + deck.Cards[i] + " " + deck.Cards[i+PlayerCount] + "] ";
            sOut += (eval.isFlush(rank[i]) ? "+" : " ") + eval.handNote(rank[i])+".";
            sOut += eval.handRank(rank[i],true) + ( (rank[i]==win) ? (split ? "  SPLIT" : "  *WIN*") : "" );
            sOut += "\r\n";
         }

         handcount++; //deal a hand to each player

         string sFmt = string.Empty;
         textBox1.Clear();
         for (int i = 0;i<10;i++) {
            if (i<=1) sFmt="-0.000% "; else sFmt="-00.00% ";
            textBox1.Text += HandEvaluator.StrHandRankEnum[i, 1] + (( double )rankcounter[i]/(handcount*PlayerCount)).ToString(sFmt);
            if (i==4) textBox1.Text+="\r\n";
         }
         textBox1.Text+="\r\n";

         textBox1.Text+= handcount.ToString() + " - Hands @" +PlayerCount.ToString()+ " players/hand\r\n";

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
         timer1.Enabled = checkBox1.Checked;
      }

      private void textBox1_DoubleClick(object sender, EventArgs e) {
         wyldeLOGIC.wyldeRNG rng = new wyldeLOGIC.wyldeRNG();
         string sTmp = rng.getGUID();
         textBox1.Text += sTmp.Substring(0, 8) + "-" + 
                           sTmp.Substring(8, 4) + "-" + 
                           sTmp.Substring(12, 4) + "-" +
                           sTmp.Substring(16) + "\r\n";
      }
   }
}
