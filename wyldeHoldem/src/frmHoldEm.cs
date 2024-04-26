using System.Windows.Forms;
using wyldePoker;

namespace wyldeHoldem {
   public partial class frmHoldEm : Form {
      //cardTable mainTable = new cardTable();
      Deck deck = new Deck();
      HandEvaluator eval = new HandEvaluator();

      public frmHoldEm() {
         InitializeComponent();
      }

      private void frmHoldEm_Load(object sender, System.EventArgs e) {
         //
      }

      private void BtnTest_Click(object sender, System.EventArgs e) {
         deck.Shuffle();

         string sOut = "";

         sOut+="[";
         for (int i = 0;i<7;i++) {
            sOut+=deck.cards[i].ToString() + " ";
         }
         sOut = sOut.Trim() + "]\r\n";

         //int r = handEval.evaluate_7cards(mainDeck.cards[0].ID,
         //                                 mainDeck.cards[1].ID,
         //                                 mainDeck.cards[2].ID,
         //                                 mainDeck.cards[3].ID,
         //                                 mainDeck.cards[4].ID,
         //                                 mainDeck.cards[5].ID,
         //                                 mainDeck.cards[6].ID);

         int r = eval.eval7(deck.cards);

         sOut += "["+eval.handNote(r)+"] "+eval.handRank(r)+"\r\n\r\n";

         string sTmp = textBox1.Text;
         textBox1.Text = sOut + sTmp;


         //for (int i = 51; i >= 0; i--) {
         //   textBox1.Text+=mainDeck.rndCard(0, i).ToString("0# ");
         //   if (((52-i)%13)==0) { textBox1.Text+="\r\n"; }
         //}
      }

      private void btnClear_Click(object sender, System.EventArgs e) {
         textBox1.Clear();
      }
   }
}
