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
        private CancellationTokenSource _canceller;
        public ulong output = 0;
        string polynomial;
        ulong maxPower = 1;
        public int size;
        ulong register = 0;
        public int numberOfIterations = 0;
        int[] indexes;
        StringBuilder stringBuilder = new StringBuilder();

         public LFSR ()
        {
            InitializeComponent ();
            Stop.Hide();
            label2.Hide();
        }
        private void Menu_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            polynomial = textBox1.Text;
        }
        public async void worker()
        {
            _canceller = new CancellationTokenSource();
            await Task.Run(() =>
            {
                do
                {
                    register=Iteration(register);
                    if (_canceller.Token.IsCancellationRequested)
                        break;

                } while (true);
            });

            _canceller.Dispose();
        }
        async void Start_Click(object sender, EventArgs e)
        {
            Initialize(polynomial);
            worker();
            Start.Hide();
            Stop.Show();
            label2.Hide();
        }

        public void Stop_Click(object sender, EventArgs e)
        {
            Stop.Hide();
            Start.Show();
            _canceller.Cancel();
            stringBuilder.Clear();
            stringBuilder.Append("Wynik: "); //generate strng
            for (int i = 32; i >= 0; i--)
                stringBuilder.Append((output >> i) % 2);
            stringBuilder.Append("\n");
            stringBuilder.Append("Ostatnia literacja: ");
            for (int i = size - 1; i >= 0; i--)
                stringBuilder.Append((register >> i) % 2);
            label2.Show();
            label2.Text = stringBuilder.ToString();
        }

        public void Initialize(string polynomial)
        {
            size = 0;
            indexes = null;
            output = 0;
            register = 0;
            maxPower = 1;
            numberOfIterations = 0;
            indexes = polynomial.Split('-').Select(n => Convert.ToInt32(n)).ToArray(); //change string to int[]   
            int n = 0;
            for (int i = 0; i < indexes.Length; i++) //find biggest power
                n = Math.Max(n, indexes[i]);
            size = n; 
            maxPower = 1;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                register = 2 * register + (ulong)rand.Next(2); //generate random sequence
                maxPower *= 2; //lenght of the sequence by bits
            }
            maxPower /= 2;
            if (register == 0 || register == maxPower) Initialize(polynomial); //generate one more time when sequence contains only 1 or 0
        }
        public ulong Iteration(ulong register)
        {
            numberOfIterations++; //count number of iteration
            output = (output << 1) + register % 2; ////xor for first bit
            ulong element = (register >> (size - indexes[0])) % 2; //xor for first bit
            for (int i = 1; i < indexes.Length; i++)
            {
                element = element ^ (register >> (size - indexes[i])) % 2; //xor for right bits from polynomial
            }
            register = register >> 1; //delete first bit
            register = register + maxPower * element; //add 1 or 0 on a first spot
            Console.WriteLine(register);
            return register;
        }

        public byte[] getBytes()
        {
            /*int n = numberOfIterations == 0 ? 1 : numberOfIterations/8;
            n = numberOfIterations % 8 > 0 ? n + 1 : n;
            n = Math.Min(n, 64/8);*/
            int n = 64 / 8;
            ulong helpregister = output;
            byte[] tab = new byte[n];
            for (int i = n - 1; helpregister > 0; i--)
            {
                tab[i] = (byte)helpregister;
                helpregister = helpregister >> 8;
            }
            return tab;
        }

        public ulong returnOutput()
        {
            return output;
        }

        public void changePolynomial(string key)
        {
            polynomial = key;
        }
    }
}
