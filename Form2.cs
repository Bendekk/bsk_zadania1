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


        public static int keyLenght;

        public static int[] numbers1;

        private void submit_Click(object sender, EventArgs e)
        {
            numbers1 = kolejnosc(key); //kolejnośc 'liter w słowie'
            keyLenght = temp.Length;
            string plainText;
            //plainText = LoadText();
            plainText = RemoveWhitespace(temp);
            //ShowKey();
            //WritePlainTextToBoard(plainText);
            //.WriteLine("encrypted text:");
            label3.Text = new string(Encrypt(plainText));
            label3.Show();

            //Console.Read();

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

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
        public static List<string> GetElevensStrings(string input)
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

        public static string Encrypt(string input)
        {
            List<string> elevensStrings = GetElevensStrings(input);
            int quant = elevensStrings.Count;
            string C = "";
            int index = 0;
            int tmp;
            char cc = ' ';

            for (int i = 0; i < keyLenght; i++)
            {
                if (i > 0)
                {
                    C = C + " ";
                }

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



        private void menu2b_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
