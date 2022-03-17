using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bsk_zadania1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label3.Hide();
        }

        string key;
        string sentence;
        private void keyText_TextChanged(object sender, EventArgs e)
        {
            key = keyText.ToString();
        }

        private void sentenceText_TextChanged(object sender, EventArgs e)
        {
            sentence = sentenceText.ToString();
        }


        private void submit_Click(object sender, EventArgs e)
        {

        }



        private void menu2b_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
