namespace bsk_zadania1
{
    partial class Macierzowe2a
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
            this.label1 = new System.Windows.Forms.Label();
            this.word = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menu2a = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.submit1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Słowo do zakodowania:";
            // 
            // word
            // 
            this.word.Location = new System.Drawing.Point(232, 53);
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(177, 31);
            this.word.TabIndex = 1;
            this.word.TextChanged += new System.EventHandler(this.word_TextChanged);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(163, 105);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(112, 34);
            this.submit.TabIndex = 2;
            this.submit.Text = "Zakoduj";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Słowo zakodowane:";
            // 
            // menu2a
            // 
            this.menu2a.Location = new System.Drawing.Point(24, 370);
            this.menu2a.Name = "menu2a";
            this.menu2a.Size = new System.Drawing.Size(112, 34);
            this.menu2a.TabIndex = 6;
            this.menu2a.Text = "Menu";
            this.menu2a.UseVisualStyleBackColor = true;
            this.menu2a.Click += new System.EventHandler(this.menu2a_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Klucz kodowania:             3-4-1-5-2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Słowo odkodowane:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // submit1
            // 
            this.submit1.Location = new System.Drawing.Point(163, 258);
            this.submit1.Name = "submit1";
            this.submit1.Size = new System.Drawing.Size(112, 34);
            this.submit1.TabIndex = 10;
            this.submit1.Text = "Odkoduj";
            this.submit1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 31);
            this.textBox1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Słowo do odkodowania:";
            // 
            // Macierzowe2a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 446);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.submit1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menu2a);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.word);
            this.Controls.Add(this.label1);
            this.Name = "Macierzowe2a";
            this.Text = "Macierzowe2a";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox word;
        private Button submit;
        private Label label2;
        private Label label3;
        private Button menu2a;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button submit1;
        private TextBox textBox1;
        private Label label7;
    }
}