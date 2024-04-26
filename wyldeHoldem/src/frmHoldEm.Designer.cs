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
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Hermit", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(12, 12);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.textBox1.Size = new System.Drawing.Size(1059, 460);
         this.textBox1.TabIndex = 0;
         // 
         // btnTest
         // 
         this.btnTest.Location = new System.Drawing.Point(832, 532);
         this.btnTest.Name = "btnTest";
         this.btnTest.Size = new System.Drawing.Size(239, 87);
         this.btnTest.TabIndex = 1;
         this.btnTest.Text = "Test";
         this.btnTest.UseVisualStyleBackColor = true;
         this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
         // 
         // frmHoldEm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(1083, 629);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.textBox1);
         this.Name = "frmHoldEm";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.frmHoldEm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button btnTest;
   }
}

