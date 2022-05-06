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
            this.zakoduj.Location = new System.Drawing.Point(21, 84);
            this.zakoduj.Name = "zakoduj";
            this.zakoduj.Size = new System.Drawing.Size(75, 23);
            this.zakoduj.TabIndex = 1;
            this.zakoduj.Text = "Zakoduj";
            this.zakoduj.UseVisualStyleBackColor = true;
            this.zakoduj.Click += new System.EventHandler(this.zakoduj_Click);
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(150, 42);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(100, 23);
            this.KeyBox.TabIndex = 2;
            this.KeyBox.TextChanged += new System.EventHandler(this.KeyBox_TextChanged);
            // 
            // Des
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}