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
    public partial class LFSR : Form
    {
        string mywielomian;
        bool start = false;
        public LFSR()
        {
            InitializeComponent();
            Stop.Hide();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mywielomian = textBox1.Text;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Stop.Show();
            start = true;
        }
        public bool[] lfsr(string wielomian)
        {
            wielomian = mywielomian;
            bool[] bits = new bool[128];
            bool[] xor = new bool[128];
            int a = 0;
            bool startint = false;
            foreach(char c in wielomian)
            {
                if(c == '^')
                {
                    startint = true;
                }
                if(Char.IsDigit(c) && startint)
                {
                    a *= 10;
                    a += int.Parse(c.ToString());
                }
                else
                {
                    xor[a] = true;
                    startint = false;
                    a = 0;
                    
                }
            }
            while(start)
            {

            }
            return bits;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            start = false;
            Stop.Hide();
        }
    }
}
