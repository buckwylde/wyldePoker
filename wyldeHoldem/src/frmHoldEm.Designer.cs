namespace wyldeHoldem
{
   partial class frmHoldEm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            pfc.Dispose();
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.btnTest = new System.Windows.Forms.Button();
         this.btnClear = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Comic Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(5, 5);
         this.textBox1.Margin = new System.Windows.Forms.Padding(1);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.textBox1.Size = new System.Drawing.Size(910, 401);
         this.textBox1.TabIndex = 0;
         // 
         // btnTest
         // 
         this.btnTest.Location = new System.Drawing.Point(727, 408);
         this.btnTest.Margin = new System.Windows.Forms.Padding(1);
         this.btnTest.Name = "btnTest";
         this.btnTest.Size = new System.Drawing.Size(188, 59);
         this.btnTest.TabIndex = 1;
         this.btnTest.Text = "Test";
         this.btnTest.UseVisualStyleBackColor = true;
         this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
         // 
         // btnClear
         // 
         this.btnClear.Location = new System.Drawing.Point(535, 408);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(188, 59);
         this.btnClear.TabIndex = 2;
         this.btnClear.Text = "Clear";
         this.btnClear.UseVisualStyleBackColor = true;
         this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
         // 
         // frmHoldEm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(925, 477);
         this.Controls.Add(this.btnClear);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.textBox1);
         this.Margin = new System.Windows.Forms.Padding(1);
         this.Name = "frmHoldEm";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.frmHoldEm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnClear;
   }
}

