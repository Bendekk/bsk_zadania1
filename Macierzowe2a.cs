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

        string myword;   //slowo do zakodwoania
        const int d = 5; //dlugosc klucza
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
                if ((i + d) <= myword.Length)  //jezeli i + dugosc kucza <dlugosci slowa do zakodowania
                {

                    substr = myword.Substring(i, d); //dzielimy slowo na dlugosc klucza 
                    
                    //przypisujemujemy do slowa zakodowanego litery w kolejnosci z klucza
                    C = C + substr[2] + substr[3] + substr[0] + substr[4] + substr[1];
                }
                else //jezeli zostalo mniej liter niz dlugosc klucza
                {
                    if (myword.Length % 5 == 1)       //sprawdzamy kazda mozliwosc i przypisujemy litery do slowa zakodowanego w kolejnosci z klucza
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
                if ((i + d) <= C.Length)//jezeli i + dugosc kucza <dlugosci slowa zakodowanego
                {
                    substr = C.Substring(i, d);//dzielimy slowo na dlugosc klucza 

                    //przypisujemujemy do slowa odkodowanego litery w kolejnosci odwrotnej do kolejnosci klucza 
                    C2 = C2 + substr[2] + substr[4] + substr[0] + substr[1] + substr[3];
                }
                else //jezeli zostalo mniej liter niz dlugosc klucza
                {
                    //sprawdzamy kazda mozliwosc i przypisujemy litery do slowa odkodowanego w kolejnosci odwrotnej do kolejnosci klucza
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
            return C2; //zwracamy slowo odkodowane
        }

        private void menu2a_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
