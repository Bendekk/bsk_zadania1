namespace bsk_zadania1
{
    partial class Form2
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
            this.menu2b = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.keyText = new System.Windows.Forms.TextBox();
            this.sentenceText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menu2b
            // 
            this.menu2b.Location = new System.Drawing.Point(33, 233);
            this.menu2b.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.menu2b.Name = "menu2b";
            this.menu2b.Size = new System.Drawing.Size(78, 20);
            this.menu2b.TabIndex = 0;
            this.menu2b.Text = "Menu";
            this.menu2b.UseVisualStyleBackColor = true;
            this.menu2b.Click += new System.EventHandler(this.menu2b_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klucz kodowania:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wyrażenie do zakodowania: ";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(33, 92);
            this.submit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(78, 20);
            this.submit.TabIndex = 5;
            this.submit.Text = "Zakoduj";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(216, 17);
            this.keyText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(106, 23);
            this.keyText.TabIndex = 7;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            // 
            // sentenceText
            // 
            this.sentenceText.Location = new System.Drawing.Point(216, 45);
            this.sentenceText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentenceText.Name = "sentenceText";
            this.sentenceText.Size = new System.Drawing.Size(106, 23);
            this.sentenceText.TabIndex = 8;
            this.sentenceText.TextChanged += new System.EventHandler(this.sentenceText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 270);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sentenceText);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu2b);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button menu2b;
        private Label label1;
        private Label label2;
        private Button submit;
        private Label label3;
        private TextBox keyText;
        private TextBox sentenceText;
        private Label label4;
    }
}