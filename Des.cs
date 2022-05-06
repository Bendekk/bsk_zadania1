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
    public partial class Des : Form
    {
        string ipt;
        ulong key;
        private static int[] nols = new int[16]{1, 1, 2, 2, 2 ,2 ,2 ,2 ,1, 2, 2, 2, 2, 2, 2, 1};

        private static int[] pc1 = new int[56]
        { 
            57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4};

        private static int[] pc2 = new int[48]
        { 
            14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32};

        public Des()
        {
            InitializeComponent();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            ipt = input.Text; 
        }
        private void KeyBox_TextChanged(object sender, EventArgs e)
        {
            key = Convert.ToUInt64(KeyBox.Text);
        }
        private void zakoduj_Click(object sender, EventArgs e)
        {
            byte[] input = new byte[1];
            input = Encoding.ASCII.GetBytes(ipt);
            uint[] state = new uint[2];
            state = IP(state, input);
            ulong[] keyCipher = new ulong[16];
            generateKey(key, keyCipher);
        }
        public uint[] IP(uint[] state, byte[] input) //Initial Permutation 
        {
            state[0] = BITNUM(input, 57, 31) | BITNUM(input, 49, 30) | BITNUM(input, 41, 29) | BITNUM(input, 33, 28) |
                BITNUM(input, 25, 27) | BITNUM(input, 17, 26) | BITNUM(input, 9, 25) | BITNUM(input, 1, 24) |
                BITNUM(input, 59, 23) | BITNUM(input, 51, 22) | BITNUM(input, 43, 21) | BITNUM(input, 35, 20) |
                BITNUM(input, 27, 19) | BITNUM(input, 19, 18) | BITNUM(input, 11, 17) | BITNUM(input, 3, 16) |
                BITNUM(input, 61, 15) | BITNUM(input, 53, 14) | BITNUM(input, 45, 13) | BITNUM(input, 37, 12) |
                BITNUM(input, 29, 11) | BITNUM(input, 21, 10) | BITNUM(input, 13, 9) | BITNUM(input, 5, 8) |
                BITNUM(input, 63, 7) | BITNUM(input, 55, 6) | BITNUM(input, 47, 5) | BITNUM(input, 39, 4) |
                BITNUM(input, 31, 3) | BITNUM(input, 23, 2) | BITNUM(input, 15, 1) | BITNUM(input, 7, 0);

            state[1] = BITNUM(input, 56, 31) | BITNUM(input, 48, 30) | BITNUM(input, 40, 29) | BITNUM(input, 32, 28) |
                BITNUM(input, 24, 27) | BITNUM(input, 16, 26) | BITNUM(input, 8, 25) | BITNUM(input, 0, 24) |
                BITNUM(input, 58, 23) | BITNUM(input, 50, 22) | BITNUM(input, 42, 21) | BITNUM(input, 34, 20) |
                BITNUM(input, 26, 19) | BITNUM(input, 18, 18) | BITNUM(input, 10, 17) | BITNUM(input, 2, 16) |
                BITNUM(input, 60, 15) | BITNUM(input, 52, 14) | BITNUM(input, 44, 13) | BITNUM(input, 36, 12) |
                BITNUM(input, 28, 11) | BITNUM(input, 20, 10) | BITNUM(input, 12, 9) | BITNUM(input, 4, 8) |
                BITNUM(input, 62, 7) | BITNUM(input, 54, 6) | BITNUM(input, 46, 5) | BITNUM(input, 38, 4) |
                BITNUM(input, 30, 3) | BITNUM(input, 22, 2) | BITNUM(input, 14, 1) | BITNUM(input, 6, 0);

            return state;
        }
        private static uint BITNUM(byte[] a, int b, int c)
        {
            return (uint)(((a[b / 8] >> (7 - (b % 8))) & 0x01) << (c)); //ustawienie bitu na odpowiednim miejscu i zamiana go na uint
        }
        private static byte BITNUMINTR(uint a, int b, int c)
        {
            return (byte)((((a) >> (31 - (b))) & 0x00000001) << (c)); //ustawienie uinta na odpowiednim miejscu i zamiana go na byte
        }
        public ulong preparekey1(ulong key)
        {
            ulong result = 0;
            for (int i = 0; i < 56; i++)
            {
                result = result << 1;
                ulong x = (key >> (64-pc1[i])) % 2;
                result += x;
            }
            return result;
        }
        public ulong preparekey2(int left, int right)
        {
            ulong leftHelp = (ulong)left;
            ulong toConversion = (leftHelp << 28) + (ulong)right;
            ulong result = 0;
            for (int i = 0; i < 48; i++)
            {
                result = result << 1;
                ulong x = (toConversion >> (56-pc2[i])) % 2;
                result += x;
            }
            return result;
        }
        public int splitBit(ulong key, bool left)
        {
            if (left)
                return (int)(key >> 28);

            return (int)(key % (268435456));
        }
        public void generateKey(ulong key, ulong[] keyCipher)
        {
            ulong result = preparekey1(key);

            int left = this.splitBit(result, true);
            int right = this.splitBit(result, false);

            for (int i = 0; i < 16; i++)
            {
                int ls = nols[i];
                int add = left >> (28 - ls);
                left = (left << ls) + add;
                left = left % 268435456;
                add = right >> (28 - ls);
                right = (right << ls) + add;
                right = right % 268435456;

                result = this.preparekey2(left, right);

                keyCipher[i] = result;
            }

        }
        private static byte[,] E = new byte[6, 8]
       {
            { 32, 4, 8, 12, 16, 20, 24, 28 },
            { 1, 5, 9, 13, 17, 21, 25, 29},
            { 2, 6, 10, 14, 18, 22, 26, 30},
            { 3, 7, 11, 15, 19, 23, 27, 31},
            { 4, 8, 12, 16, 20, 24, 28, 32},
            { 5, 9, 13, 17, 21, 25, 29, 1},
       };


    }
}
