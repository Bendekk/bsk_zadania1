namespace bsk_zadania1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.macierzowe2a = new System.Windows.Forms.Button();
            this.macierzowe2b = new System.Windows.Forms.Button();
            this.LFSR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rail Fance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // macierzowe2a
            // 
            this.macierzowe2a.Location = new System.Drawing.Point(119, 8);
            this.macierzowe2a.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.macierzowe2a.Name = "macierzowe2a";
            this.macierzowe2a.Size = new System.Drawing.Size(105, 30);
            this.macierzowe2a.TabIndex = 1;
            this.macierzowe2a.Text = "Macierzowe 2a";
            this.macierzowe2a.UseVisualStyleBackColor = true;
            this.macierzowe2a.Click += new System.EventHandler(this.macierzowe2a_Click);
            // 
            // macierzowe2b
            // 
            this.macierzowe2b.Location = new System.Drawing.Point(228, 8);
            this.macierzowe2b.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.macierzowe2b.Name = "macierzowe2b";
            this.macierzowe2b.Size = new System.Drawing.Size(105, 30);
            this.macierzowe2b.TabIndex = 2;
            this.macierzowe2b.Text = "Macierzowe 2b";
            this.macierzowe2b.UseVisualStyleBackColor = true;
            this.macierzowe2b.Click += new System.EventHandler(this.macierzowe2b_Click);
            // 
            // LFSR
            // 
            this.LFSR.Location = new System.Drawing.Point(9, 44);
            this.LFSR.Name = "LFSR";
            this.LFSR.Size = new System.Drawing.Size(102, 33);
            this.LFSR.TabIndex = 3;
            this.LFSR.Text = "LFSR";
            this.LFSR.UseVisualStyleBackColor = true;
            this.LFSR.Click += new System.EventHandler(this.LFSR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 89);
            this.Controls.Add(this.LFSR);
            this.Controls.Add(this.macierzowe2b);
            this.Controls.Add(this.macierzowe2a);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button macierzowe2a;
        private Button macierzowe2b;
        private Button LFSR;
    }
}