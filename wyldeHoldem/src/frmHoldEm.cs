using System.Drawing.Text;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using wyldePoker;

namespace wyldeHoldem {
   public partial class frmHoldEm : Form {

      //cardTable mainTable = new cardTable();
      Deck deck = new Deck();
      HandEvaluator eval = new HandEvaluator();
      PrivateFontCollection pfc = new PrivateFontCollection();

      public frmHoldEm() { // constructor
         
         InitializeComponent();

         pfc.AddFontFile(Application.StartupPath + "\\ComicMono.ttf");
         textBox1.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);

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

         int r = eval.Eval(deck.cards, 7);

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
