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
    public partial class SzyfrowanieStrumieniowe : Form
    {
        public string stringToEncrypt;
        public string key;
        public byte[] data;
        public byte[] temp;

        LFSR lfsr = new LFSR();
        

        public SzyfrowanieStrumieniowe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            lfsr.Stop_Click(sender, e);
            data = Encoding.ASCII.GetBytes(stringToEncrypt);
            temp = XorOperation(data);
            label2.Text = System.Text.Encoding.UTF8.GetString(temp);
        }

        private byte[] XorOperation(byte[] temporary)
        {
            byte[] key = lfsr.getBytes();
            byte[] output = new byte[temporary.Length];
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
            encoded.Text = System.Text.Encoding.UTF8.GetString(XorOperation(temp));
        }
    }
}
