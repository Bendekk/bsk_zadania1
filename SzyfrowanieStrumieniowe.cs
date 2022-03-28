using System;
using System.Collections;
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
    public partial class SzyfrowanieStrumieniowe : Form
    {
        public string stringToEncrypt;  
        public string key;
        public byte[] data;
        public byte[] temp;
        public string s;

        LFSR lfsr = new LFSR();
        

        public SzyfrowanieStrumieniowe()
        {
            InitializeComponent();
            button3.Hide();
            button4.Hide();
            label2.Hide();
            label4.Hide();
            encoded.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Hide();
            label4.Show();
            button3.Show();
            button2.Show();
            lfsr.Initialize(key);
            lfsr.worker();
        }

        private void toEncrypt_TextChanged(object sender, EventArgs e)
        {
            stringToEncrypt = toEncrypt.Text;
        }

        private void keyText_TextChanged(object sender, EventArgs e)
        {
            key = keyText.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Show();
            label2.Show();
            label4.Hide();

            lfsr.Stop_Click(sender, e);                         //stop gerating key need to encript
            data = Encoding.ASCII.GetBytes(stringToEncrypt);    //array of bytes  string to encritp
            temp = XorOperation(data);                          //xor operations on array of bytes
            s = string.Join(" ",temp.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))); //change bytes to bits
        }

        private byte[] XorOperation(byte[] temporary)
        {
            byte[] key = lfsr.getBytes();                   //divide sting to bytes
            byte[] output = new byte[temporary.Length];     //new array of bytes (lenght of string to encript)
            int keyIndex = 0;
            for (int i = 0; i < temporary.Length; i++)
            {
                output[i] = (byte)(temporary[i] ^ key[keyIndex]);
                keyIndex++;
                keyIndex = keyIndex % key.Length;
            }
            return output;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            encoded.Show();
            encoded.Text = System.Text.Encoding.UTF8.GetString(XorOperation(temp));
        }
    }
}
