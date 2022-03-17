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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rail Fance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // macierzowe2a
            // 
            this.macierzowe2a.Location = new System.Drawing.Point(170, 14);
            this.macierzowe2a.Name = "macierzowe2a";
            this.macierzowe2a.Size = new System.Drawing.Size(150, 50);
            this.macierzowe2a.TabIndex = 1;
            this.macierzowe2a.Text = "Macierzowe 2a";
            this.macierzowe2a.UseVisualStyleBackColor = true;
            this.macierzowe2a.Click += new System.EventHandler(this.macierzowe2a_Click);
            // 
            // macierzowe2b
            // 
            this.macierzowe2b.Location = new System.Drawing.Point(326, 14);
            this.macierzowe2b.Name = "macierzowe2b";
            this.macierzowe2b.Size = new System.Drawing.Size(150, 50);
            this.macierzowe2b.TabIndex = 2;
            this.macierzowe2b.Text = "Macierzowe 2b";
            this.macierzowe2b.UseVisualStyleBackColor = true;
            this.macierzowe2b.Click += new System.EventHandler(this.macierzowe2b_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 149);
            this.Controls.Add(this.macierzowe2b);
            this.Controls.Add(this.macierzowe2a);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button macierzowe2a;
        private Button macierzowe2b;
    }
}