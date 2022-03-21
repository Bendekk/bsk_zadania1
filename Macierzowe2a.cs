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
    public partial class Macierzowe2a : Form
    {
        public Macierzowe2a()
        {
            InitializeComponent();
            label2.Hide();
            label6.Hide();
        }

        string myword;
        const int d = 5;
        private void word_TextChanged(object sender, EventArgs e)
        {
            myword = word.Text;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            //key = 3-4-1-5-2
            string C = macierzowa2aEncrypt(myword);
            label2.Text = new string(C);
            label2.Show();
            string C2 = macierzowa2aDecrypt(C);
            label6.Text = new string(C2);
            label6.Show();
        }
        public string macierzowa2aEncrypt(string myword)
        {
            //key = 3-4-1-5-2
            string C = "", substr = "";
            for (int i = 0; i <= myword.Length; i = i + d)
            {
                if ((i + d) <= myword.Length)
                {

                    substr = myword.Substring(i, d);
                    C = C + substr[2] + substr[3] + substr[0] + substr[4] + substr[1];
                }
                else
                {
                    if (myword.Length % 5 == 1)
                    {
                        substr = myword.Substring(i, 1);
                        C = C + substr[0];
                    }
                    if (myword.Length % 5 == 2)
                    {
                        substr = myword.Substring(i, 2);
                        C = C + substr[0] + substr[1];
                    }
                    if (myword.Length % 5 == 3)
                    {
                        substr = myword.Substring(i, 3);
                        C = C + substr[2] + substr[0] + substr[1];
                    }
                    if (myword.Length % 5 == 4)
                    {
                        substr = myword.Substring(i, 4);
                        C = C + substr[2] + substr[3] + substr[0] + substr[1];
                    }
                }
            }
            return C;
        }
        public string macierzowa2aDecrypt(string C)
        {
            string C2 = "";
            string substr = "";
            for (int i = 0; i <= C.Length; i = i + d)
            {
                if ((i + d) <= C.Length)
                {
                    substr = C.Substring(i, d);
                    C2 = C2 + substr[2] + substr[4] + substr[0] + substr[1] + substr[3];
                }
                else
                {
                    if (C.Length % 5 == 1)
                    {
                        substr = C.Substring(i, 1);
                        C2 = C2 + substr[0];
                    }
                    if (C.Length % 5 == 2)
                    {
                        substr = C.Substring(i, 2);
                        C2 = C2 + substr[0] + substr[1];
                    }
                    if (C.Length % 5 == 3)
                    {
                        substr = C.Substring(i, 3);
                        C2 = C2 + substr[2] + substr[0] + substr[1];
                    }
                    if (C.Length % 5 == 4)
                    {
                        substr = C.Substring(i, 4);
                        C2 = C2 + substr[2] + substr[0] + substr[1] + substr[3];
                    }
                }
            }
            return C2;
        }

        private void menu2a_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
