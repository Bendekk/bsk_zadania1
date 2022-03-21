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
            label4.Hide();
        }

        public static string key;
        public string temp;
        private void keyText_TextChanged(object sender, EventArgs e)
        {
            key = keyText.Text;
        }

        private void sentenceText_TextChanged(object sender, EventArgs e)
        {
            temp = sentenceText.Text;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            label3.Text = new string(Encrypt(temp,key));
            label3.Show();
            label4.Text = new string(Decrypt(label3.Text, key));
            label4.Show();
        }

        public static int[] kolejnosc(string key)
        {
            string x = key;
            char[] word = x.ToCharArray();
            char[] toSort = x.ToCharArray();
            int[] sorted = new int[x.Length];
            Array.Sort(toSort);
            for (int i = 0; i < toSort.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[i] == toSort[j])
                    {
                        toSort[j] = '-';
                        sorted[i] = j + 1;
                        break;
                    }
                }
            }
            return sorted;
        }

        public static List<string> GetElevensStrings(string input, int keyLenght, string key)
        {
            List<string> elevensStrings = new List<string>();
            for (int i = 0; i <= input.Length; i = i + keyLenght)
            {
                if ((i + key.Length) < input.Length)
                    elevensStrings.Add(input.Substring(i, keyLenght));
                else
                    elevensStrings.Add(input.Substring(i));
            }
            return elevensStrings;
        }

        public string Encrypt(string input, string key)
        {
            int keyLenght = key.Length;
            int[] numbers1 = kolejnosc(key);
            List<string> elevensStrings = GetElevensStrings(input, keyLenght,key);
            int quant = elevensStrings.Count;
            string C = "";
            int index = 0;
            int tmp;
            char cc = ' ';
            for (int i = 0; i < keyLenght; i++)
            {
                tmp = i + 1;
                int v = Array.IndexOf(numbers1, tmp);
                index = v;
                for (int j = 0; j < quant; j++)
                {
                    if (elevensStrings.ElementAt(j).Length >= index + 1) //dodalem "+1" bo ostatnich 4 liter nie wypisywalo
                    {
                        cc = elevensStrings.ElementAt(j)[index];
                        C = C + cc;
                    }
                }
            }
            return C;
        }

        public string Decrypt(string text,string key)
        {
            int[] numbers1 = kolejnosc(key);
            string output = "";
            char[,] tab = new char[numbers1.Length, (int)text.Length / numbers1.Length + 1];
            int modulo = text.Length % numbers1.Length;
            int index = 0;
            for (int i = 0; i < numbers1.Length; i++)
            {
                if (Array.IndexOf(numbers1, i + 1) < modulo)
                {
                    for (int j = 0; j < (int)text.Length / numbers1.Length + 1; j++)
                    {
                        if (index <= text.Length - 1)
                        {
                            tab[Array.IndexOf(numbers1, i + 1), j] = text[index];

                            index++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < (int)text.Length / numbers1.Length; j++)
                    {
                        if (index <= text.Length - 1)
                        {
                            tab[Array.IndexOf(numbers1, i + 1), j] = text[index];

                            index++;
                        }
                    }
                }
            }
            for (int k = 0; k < (int)text.Length / numbers1.Length + 1; k++)
            {
                for (int g = 0; g < numbers1.Length; g++)
                {
                    if (tab[g, k] != '\0')
                        output += tab[g, k];
                }
            }
            return output;
        }
        private void menu2b_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
