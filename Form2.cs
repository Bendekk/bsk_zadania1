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

        //przypisanie kolejnosci literom z klucza
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

        //podzielnie tekstu do zakodowania na 'stringi' o dlugosci klucza
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
            int keyLenght = key.Length;     //dlugość klucza
            int[] numbers1 = kolejnosc(key); // kolejnosc liter' np. dla CONVENIENCE = [1,10,7,11,3,8,6,4,9,2,5]
            List<string> elevensStrings = GetElevensStrings(input, keyLenght,key); //podzielenie stringa przez dlugosc klucza
            int quant = elevensStrings.Count;  //ilosc liter w podzielonym stringu
            string C = "";
            int index = 0;
            int tmp;
            char cc = ' ';
            for (int i = 0; i < keyLenght; i++)
            {
                tmp = i + 1;
                int v = Array.IndexOf(numbers1, tmp);//którą kolumne należy wziąć w danej iteracji
                index = v;
                for (int j = 0; j < quant; j++)
                {
                    //jezeli liczba liter w podzielonym stringu jest >= 'numeru litery'
                    if (elevensStrings.ElementAt(j).Length >= index + 1) //dodalem "+1" bo ostatnich 4 liter nie wypisywalo
                    {
                        cc = elevensStrings.ElementAt(j)[index];
                        C = C + cc;//przypisanie litery do zakodowanego stringa
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
            int modulo = text.Length % numbers1.Length; //sprawdzamy jak, sie dzieli slowo
            int index = 0;
            for (int i = 0; i < numbers1.Length; i++) //długość klucza
            {
                if (Array.IndexOf(numbers1, i + 1) < modulo) //sprawdzamy jak dużo liter jest w kolumnie (jesli klucz dl = 5, a slowo dl = 6 na pierszej kolumnie są 2 litery, na reszcie 1)
                {
                    for (int j = 0; j < (int)text.Length / numbers1.Length + 1; j++) //przechodzimy po wszystkich literach w danej "kolumnie" (ilość przejść = modulo +1),
                    {
                        if (index <= text.Length - 1) //zabezpieczenie klucz dłuższy niż slowo
                        {
                            tab[Array.IndexOf(numbers1, i + 1), j] = text[index]; //przypisujemy w odpowiednie miejsce litere z zaszyfrowanego tekstu

                            index++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < (int)text.Length / numbers1.Length; j++) //przechodzimy po wszystkich literach w kolumnie (ilość przejśc = modulo)
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
                        output += tab[g, k]; //złożenie stringów w całość
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
