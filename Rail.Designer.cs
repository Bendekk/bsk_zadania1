namespace bsk_zadania1
{
    partial class Rail
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
            this.word = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.key = new System.Windows.Forms.NumericUpDown();
            this.Submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.key)).BeginInit();
            this.SuspendLayout();
            // 
            // word
            // 
            this.word.Location = new System.Drawing.Point(63, 27);
            this.word.Name = "word";
            this.word.Size = new System.Drawing.Size(100, 23);
            this.word.TabIndex = 1;
            this.word.TextChanged += new System.EventHandler(this.word_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "KEY:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Word";
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(12, 27);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(39, 23);
            this.key.TabIndex = 4;
            this.key.ValueChanged += new System.EventHandler(this.key_ValueChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(12, 56);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "2";
            // 
            // Menu
            // 
            this.Menu.Location = new System.Drawing.Point(12, 152);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(75, 23);
            this.Menu.TabIndex = 8;
            this.Menu.Text = "Menu";
            this.Menu.UseVisualStyleBackColor = true;
            this.Menu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // Rail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 200);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.word);
            this.Name = "Rail";
            this.Text = "Rail";
            ((System.ComponentModel.ISupportInitialize)(this.key)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox word;
        private Label label1;
        private Label label2;
        private NumericUpDown key;
        private Button Submit;
        private Label label3;
        private Label label4;
        private Button Menu;
    }
}