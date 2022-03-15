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
    public partial class Rail : Form
    {
        int mykey;
        string myword;

        public Rail()
        {
            InitializeComponent();
            label3.Hide();
            label4.Hide(); 
        }

        private void key_ValueChanged(object sender, EventArgs e)
        {
            mykey = Convert.ToInt32(Math.Round(key.Value, 0));
        }

        private void word_TextChanged(object sender, EventArgs e)
        {
            myword = word.Text;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            //encrypt
            List<string> railFencecode = new List<string>();
            for (int i = 0; i < mykey; i++)
            {
                railFencecode.Add("");
            }

            int number = 0;
            int increment = 1;
            foreach (char c in myword)
            {
                if (number + increment == mykey)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFencecode[number] += c;
                number += increment;
            }

            string buffer = "";
            foreach (string s in railFencecode)
            {
                buffer += s;
            }
            string code = new string(buffer);
            label3.Text = code;
            label3.Show();
            //decrypt
            int cipherLength = myword.Length;
            List<List<int>> railFencedecode = new List<List<int>>();
            for (int i = 0; i < mykey; i++)
            {
                railFencedecode.Add(new List<int>());
            }

            number = 0;
            increment = 1;
            for (int i = 0; i < cipherLength; i++)
            {
                if (number + increment == mykey)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFencedecode[number].Add(i);
                number += increment;
            }

            int counter = 0;
            char[] buffer2 = new char[cipherLength];
            for (int i = 0; i < mykey; i++)
            {
                for (int j = 0; j < railFencedecode[i].Count; j++)
                {
                    buffer2[railFencedecode[i][j]] = code[counter];
                    counter++;
                }
            }
            string code2 = new string(buffer2);
            label4.Text = code2;
            label4.Show();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();    
            this.Hide();
        }
    }
}
