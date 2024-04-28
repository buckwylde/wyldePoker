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
         if (disposing && (components != null)) {
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoldEm));
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.btnTest = new System.Windows.Forms.Button();
         this.btnChunk = new System.Windows.Forms.Button();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // textBox1
         // 
         this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBox1.Font = new System.Drawing.Font("Comic Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(5, 5);
         this.textBox1.Margin = new System.Windows.Forms.Padding(1);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.textBox1.Size = new System.Drawing.Size(429, 406);
         this.textBox1.TabIndex = 0;
         this.textBox1.Text = resources.GetString("textBox1.Text");
         // 
         // btnTest
         // 
         this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnTest.Location = new System.Drawing.Point(295, 417);
         this.btnTest.Margin = new System.Windows.Forms.Padding(1);
         this.btnTest.Name = "btnTest";
         this.btnTest.Size = new System.Drawing.Size(140, 59);
         this.btnTest.TabIndex = 1;
         this.btnTest.Text = "Test";
         this.btnTest.UseVisualStyleBackColor = true;
         this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
         // 
         // btnChunk
         // 
         this.btnChunk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnChunk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.btnChunk.Location = new System.Drawing.Point(150, 417);
         this.btnChunk.Name = "btnChunk";
         this.btnChunk.Size = new System.Drawing.Size(140, 59);
         this.btnChunk.TabIndex = 2;
         this.btnChunk.Text = "10K Chunk";
         this.btnChunk.UseVisualStyleBackColor = true;
         this.btnChunk.Click += new System.EventHandler(this.btnChunk_Click);
         // 
         // timer1
         // 
         this.timer1.Interval = 5;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // checkBox1
         // 
         this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
         this.checkBox1.Location = new System.Drawing.Point(5, 417);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(140, 59);
         this.checkBox1.TabIndex = 4;
         this.checkBox1.Text = "Continuous";
         this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // frmHoldEm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(444, 486);
         this.Controls.Add(this.checkBox1);
         this.Controls.Add(this.btnChunk);
         this.Controls.Add(this.btnTest);
         this.Controls.Add(this.textBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Margin = new System.Windows.Forms.Padding(1);
         this.MinimumSize = new System.Drawing.Size(460, 525);
         this.Name = "frmHoldEm";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Text = "wyldePoker Test";
         this.Load += new System.EventHandler(this.frmHoldEm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button btnTest;
      private System.Windows.Forms.Button btnChunk;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.CheckBox checkBox1;
   }
}

