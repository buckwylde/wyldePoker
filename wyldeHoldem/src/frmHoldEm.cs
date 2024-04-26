using System.Windows.Forms;
using wyldePoker;

namespace wyldeHoldem {
   public partial class frmHoldEm : Form {
      //cardTable mainTable = new cardTable();
      Deck mainDeck = new Deck();

      public frmHoldEm() {
         InitializeComponent();
      }

      private void frmHoldEm_Load(object sender, System.EventArgs e) {
         //
      }

      private void BtnTest_Click(object sender, System.EventArgs e) {
         mainDeck.Shuffle();
         textBox1.Clear();

         for (int i = 0;i<4;i++) {

            textBox1.Text+="\r\n";
         }

         //for (int i = 51; i >= 0; i--) {
         //   textBox1.Text+=mainDeck.rndCard(0, i).ToString("0# ");
         //   if (((52-i)%13)==0) { textBox1.Text+="\r\n"; }
         //}
      }
   }
}
