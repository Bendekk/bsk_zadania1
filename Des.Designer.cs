namespace bsk_zadania1
{
    partial class Des
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
            this.input = new System.Windows.Forms.TextBox();
            this.zakoduj = new System.Windows.Forms.Button();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.Dec = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Before = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.de = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(21, 42);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(100, 23);
            this.input.TabIndex = 0;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // zakoduj
            // 
            this.zakoduj.Location = new System.Drawing.Point(22, 154);
            this.zakoduj.Name = "zakoduj";
            this.zakoduj.Size = new System.Drawing.Size(75, 23);
            this.zakoduj.TabIndex = 1;
            this.zakoduj.Text = "Zakoduj";
            this.zakoduj.UseVisualStyleBackColor = true;
            this.zakoduj.Click += new System.EventHandler(this.zakoduj_Click);
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(21, 92);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(100, 23);
            this.KeyBox.TabIndex = 2;
            this.KeyBox.TextChanged += new System.EventHandler(this.KeyBox_TextChanged);
            // 
            // Dec
            // 
            this.Dec.AutoSize = true;
            this.Dec.Location = new System.Drawing.Point(182, 232);
            this.Dec.Name = "Dec";
            this.Dec.Size = new System.Drawing.Size(0, 15);
            this.Dec.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Słowo do zakodowania";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Klucz (tylko liczby)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zakodowane słowo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Słowo przed zakodowaniem";
            // 
            // Before
            // 
            this.Before.AutoSize = true;
            this.Before.Location = new System.Drawing.Point(182, 201);
            this.Before.Name = "Before";
            this.Before.Size = new System.Drawing.Size(0, 15);
            this.Before.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Odkodowane słowo";
            // 
            // de
            // 
            this.de.AutoSize = true;
            this.de.Location = new System.Drawing.Point(182, 266);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(0, 15);
            this.de.TabIndex = 10;
            // 
            // Des
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.de);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Before);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dec);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.zakoduj);
            this.Controls.Add(this.input);
            this.Name = "Des";
            this.Text = "Des";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox input;
        private Button zakoduj;
        private TextBox KeyBox;
        private Label Dec;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label Before;
        private Label label5;
        private Label de;
    }
}