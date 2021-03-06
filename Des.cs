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
        string stringkey;
        private static int[] nols = new int[16]{1, 1, 2, 2, 2 ,2 ,2 ,2 ,1, 2, 2, 2, 2, 2, 2, 1}; //tabela przesunięc pkt.6

        private static int[] pc1 = new int[56] //pkt 4
        { 
            57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4};

        private static int[] pc2 = new int[48] //pkt 7
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
            stringkey = KeyBox.Text;
        }
        private void zakoduj_Click(object sender, EventArgs e)
        {
            ulong key;
            key = Convert.ToUInt64(stringkey);
            byte[] input = new byte[8];
            byte[] output = new byte[8];
            byte[] deOutput = new byte[8];
            input = Encoding.ASCII.GetBytes(ipt);
            string s = string.Join(" ", input.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            string st = "";
            string[] subs = s.Split(' ');
            for (int i=0;i<8;++i)
            {
                st += subs[i]+" ";
            }
            ulong[] keyCipher = new ulong[16];
            generateKey(key, keyCipher);
            desCipher(input, output, keyCipher);
            Before.Text = st;
            Dec.Text = string.Join(" ", output.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            desDecipher(output, deOutput, keyCipher);
            de.Text = string.Join(" ", deOutput.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
        }
        public uint[] IP(uint[] state, byte[] input) //Initial Permutation pkt 2
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
        public ulong preparekey1(ulong key) //zmiana dlugości klucza z 64bit na 56 pkt 4 
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
        public ulong preparekey2(int left, int right) //łączymy dwa bloki i zmieniamy długość z 56bit na 48 pkt 7
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
        public int splitBit(ulong key, bool left) //dzielimy klucz na dwie części pkt 5
        {
            if (left)
                return (int)(key >> 28);

            return (int)(key % (268435456));
        }
        public void generateKey(ulong key, ulong[] keyCipher) //cały process generowania klucza key-64bit klucz, keyCipher[16] 16 wyjściowych kluczy
        {
            ulong result = preparekey1(key); ////zmiana dlugości klucza z 64bit na 56 pkt 4 

            int left = this.splitBit(result, true); //dzielimy klucz na dwie części pkt 5
            int right = this.splitBit(result, false);

            for (int i = 0; i < 16; i++) //przesuwamy dla każdego klucza bity o odpowiednią ilość zawartą w tyablicy nols pkt 6
            {
                int ls = nols[i];
                int add = left >> (28 - ls);
                left = (left << ls) + add;
                left = left % 268435456;
                add = right >> (28 - ls);
                right = (right << ls) + add;
                right = right % 268435456;

                result = this.preparekey2(left, right); //łączymy dwa bloki i zmieniamy długość z 56bit na 48 pkt 7

                keyCipher[i] = result;
            }

        }

        private static byte[,] E = new byte[6, 8] //pkt 8
        {
            { 32, 4, 8, 12, 16, 20, 24, 28 },
            { 1, 5, 9, 13, 17, 21, 25, 29},
            { 2, 6, 10, 14, 18, 22, 26, 30},
            { 3, 7, 11, 15, 19, 23, 27, 31},
            { 4, 8, 12, 16, 20, 24, 28, 32},
            { 5, 9, 13, 17, 21, 25, 29, 1},
        };

        private static byte[,] P = new byte[4, 8] //pkt 14
        {
            { 16, 29, 1, 5, 2, 32, 19, 22},
            { 7, 12, 15, 18, 8, 27, 13, 11},
            { 20, 28, 23, 31, 24, 3, 30, 4},
            { 21, 17, 26, 10, 14, 9, 6, 25}
        };
        private static byte[,] s1 = new byte[16, 4]
        {
            { 14, 0 , 4, 15 },
            { 4, 15, 1, 12 },
            { 13, 7, 14, 8 },
            { 1, 4, 8, 2 },
            { 2, 14, 13, 4 },
            { 15, 2, 6, 9 },
            { 11, 13, 2, 1 },
            { 8, 1, 11, 7 },
            { 3, 10, 15, 5 },
            { 10, 6, 12, 11 },
            { 6, 12, 9, 3 },
            { 12, 11, 7, 14 },
            { 5, 9, 3, 10 },
            { 9, 5, 10, 0 },
            { 0, 3, 5, 6 },
            { 7, 8, 0, 13 }
        }; //pkt 12

        private static byte[,] s2 = new byte[16, 4]
        {
            { 15, 3, 0, 13 },
            { 1, 13, 14, 8 },
            { 8, 4, 7, 10},
            { 14, 7, 11, 1 },
            { 6, 15, 10, 3 },
            { 11, 2, 4, 15 },
            { 3, 8, 13, 4 },
            { 4, 14, 1, 2 },
            { 9, 12, 5, 11 },
            { 7, 0, 8, 6 },
            { 2, 1, 12, 7 },
            { 13, 10, 6, 12 },
            { 12, 6, 9, 0},
            { 0, 9, 3, 5 },
            { 5, 11, 2, 14 },
            { 10, 5, 15, 9 }
        };

        private static byte[,] s3 = new byte[16, 4]
        {
            { 10, 13, 13, 1 },
            { 0, 7, 6, 10},
            { 9, 0, 4, 13 },
            { 14, 9, 9, 0 },
            { 6, 3, 8, 6 },
            { 3, 4, 15, 9 },
            { 15, 6, 3, 8 },
            { 5, 10, 0, 7 },
            { 1, 2, 11, 4},
            { 13, 8, 1, 15 },
            { 12, 5, 2, 14 },
            { 7, 14, 12, 3 },
            { 11, 12, 5, 11 },
            { 4, 11, 10, 5},
            { 2, 15, 14, 2},
            { 8, 1, 7, 12 }
        };

        private static byte[,] s4 = new byte[16, 4]
        {
            { 7, 13, 10, 3 },
            { 13, 8, 6, 15},
            { 14, 11, 9, 0},
            { 3, 5, 0, 6},
            { 0, 6, 12, 10},
            { 6, 15, 11, 1},
            { 9, 0, 7, 13},
            { 10, 3, 13, 8 },
            { 1, 4, 15, 9},
            { 2, 7, 1, 4},
            { 8, 2, 3, 5},
            { 5, 12, 14, 11},
            { 11, 1, 5, 12},
            { 12, 10, 2, 7},
            { 4, 14, 8, 2},
            { 15, 9, 4, 14}
        };

        private static byte[,] s5 = new byte[16, 4]
        {
            { 2, 14, 4, 11 },
            { 12, 11, 2, 8},
            { 4, 2, 1, 12},
            { 1, 12, 11, 7},
            { 7, 4, 10, 1},
            { 10, 7, 13, 14},
            { 11, 13, 7, 2},
            { 6, 1, 8, 13},
            { 8, 5, 15, 6},
            { 5, 0, 9, 15},
            { 3, 15, 12, 0},
            { 15, 10, 5, 9},
            { 13, 3, 6, 10},
            { 0, 9, 3, 4},
            { 14, 8, 0, 5},
            { 9, 6, 14, 3}
        };

        private static byte[,] s6 = new byte[16, 4]
        {
            { 12, 10, 9, 4},
            { 1, 15, 14, 3},
            { 10, 4, 15, 2},
            { 15, 2, 5, 12},
            { 9, 7, 2, 9},
            { 2, 12, 8, 5},
            { 6, 9, 12, 15},
            { 8, 5, 3, 10},
            { 0, 6, 7, 11},
            { 13, 1, 0, 14},
            { 3, 13, 4, 1},
            { 4, 14, 10, 7},
            { 14, 0, 1, 6},
            { 7, 11, 13, 0},
            { 5, 3, 11, 8},
            { 11, 8, 6, 13 }
        };

        private static byte[,] s7 = new byte[16, 4]
        {
            { 4, 13, 1, 6 },
            { 11, 0, 4, 11},
            { 2, 11, 11, 13},
            { 14, 7, 13, 8},
            { 15, 4, 12, 1},
            { 0, 9, 3, 4},
            { 8, 1, 7, 10},
            { 13, 10, 14, 7},
            { 3, 14, 10, 9},
            { 12, 3, 15, 5},
            { 9, 5, 6, 0},
            { 7, 12, 8, 15},
            { 5, 2, 0, 14},
            { 10, 15, 5, 2},
            { 6, 8, 9, 3},
            { 1, 6, 2, 12}
        };

        private static byte[,] s8 = new byte[16, 4]
        {
            { 13, 1, 7, 2 },
            { 2, 15, 11, 1},
            { 8, 13, 4, 14},
            { 4, 8, 1, 7},
            { 6, 10, 9, 4},
            { 15, 3, 12, 10},
            { 11, 7, 14, 8},
            { 1, 4, 2, 13},
            { 10, 12, 0, 15},
            { 9, 5, 6, 12},
            { 3, 6, 10, 9},
            { 14, 11, 13, 0},
            { 5, 0, 15, 3},
            { 0, 14, 3, 5},
            { 12, 9, 5, 6},
            { 7, 2, 8, 11}
        };

        public uint functionF(uint R, ulong key) //pkt8-14
        {
            ulong Rchanged = 0;
            uint beforeOutput = 0;
            for (int i = 0; i < 8; i++) //przekształcenie 32-bit to 48bit z uzyciem tablicy E pkt8
                for (int j = 0; j < 6; j++)
                {
                    Rchanged = Rchanged << 1;
                    Rchanged += (R >> (32 - E[j, i])) % 2; 
                }

            List<byte[,]> s = new List<byte[,]>();
            ulong xorResult = Rchanged ^ key; //xor pkt 9
            s.Add(s1); s.Add(s2); s.Add(s3); s.Add(s4); s.Add(s5); s.Add(s6); s.Add(s7); s.Add(s8);
            for (int i = 1; i <= 8; i++) 
            {
                byte row = 0, column = 0, offset; //podział na 8 ciagów 6-bit pkt 10 i 11
                offset = (byte)(48 - i * 6);
                row = (byte)((xorResult >> offset) % 2);
                column = (byte)((xorResult >> (offset + 1)) % 16);
                row += (byte)(((xorResult >> (offset + 5)) % 2) * 2);

                beforeOutput = beforeOutput << 4;
                beforeOutput += (uint)s[i - 1][column, row]; //wybranie odpowiednich danych z tablicy s[i] pkt 12 i 13
            }

            uint output = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 4; j++)
                {
                    output = output << 1;
                    output += (beforeOutput >> (32 - P[j, i])) % 2; //modyfikacja przy uzyciu permutacji P pkt 14
                }
            return output;
        }

        private static byte[] InvIP(uint[] state, byte[] input)
        {
            input[0] = (byte)(BITNUMINTR(state[1], 7, 7) | BITNUMINTR(state[0], 7, 6) | BITNUMINTR(state[1], 15, 5) |
                BITNUMINTR(state[0], 15, 4) | BITNUMINTR(state[1], 23, 3) | BITNUMINTR(state[0], 23, 2) |
                BITNUMINTR(state[1], 31, 1) | BITNUMINTR(state[0], 31, 0));

            input[1] = (byte)(BITNUMINTR(state[1], 6, 7) | BITNUMINTR(state[0], 6, 6) | BITNUMINTR(state[1], 14, 5) |
                BITNUMINTR(state[0], 14, 4) | BITNUMINTR(state[1], 22, 3) | BITNUMINTR(state[0], 22, 2) |
                BITNUMINTR(state[1], 30, 1) | BITNUMINTR(state[0], 30, 0));

            input[2] = (byte)(BITNUMINTR(state[1], 5, 7) | BITNUMINTR(state[0], 5, 6) | BITNUMINTR(state[1], 13, 5) |
                BITNUMINTR(state[0], 13, 4) | BITNUMINTR(state[1], 21, 3) | BITNUMINTR(state[0], 21, 2) |
                BITNUMINTR(state[1], 29, 1) | BITNUMINTR(state[0], 29, 0));

            input[3] = (byte)(BITNUMINTR(state[1], 4, 7) | BITNUMINTR(state[0], 4, 6) | BITNUMINTR(state[1], 12, 5) |
                BITNUMINTR(state[0], 12, 4) | BITNUMINTR(state[1], 20, 3) | BITNUMINTR(state[0], 20, 2) |
                BITNUMINTR(state[1], 28, 1) | BITNUMINTR(state[0], 28, 0));

            input[4] = (byte)(BITNUMINTR(state[1], 3, 7) | BITNUMINTR(state[0], 3, 6) | BITNUMINTR(state[1], 11, 5) |
                BITNUMINTR(state[0], 11, 4) | BITNUMINTR(state[1], 19, 3) | BITNUMINTR(state[0], 19, 2) |
                BITNUMINTR(state[1], 27, 1) | BITNUMINTR(state[0], 27, 0));

            input[5] = (byte)(BITNUMINTR(state[1], 2, 7) | BITNUMINTR(state[0], 2, 6) | BITNUMINTR(state[1], 10, 5) |
                BITNUMINTR(state[0], 10, 4) | BITNUMINTR(state[1], 18, 3) | BITNUMINTR(state[0], 18, 2) |
                BITNUMINTR(state[1], 26, 1) | BITNUMINTR(state[0], 26, 0));

            input[6] = (byte)(BITNUMINTR(state[1], 1, 7) | BITNUMINTR(state[0], 1, 6) | BITNUMINTR(state[1], 9, 5) |
                BITNUMINTR(state[0], 9, 4) | BITNUMINTR(state[1], 17, 3) | BITNUMINTR(state[0], 17, 2) |
                BITNUMINTR(state[1], 25, 1) | BITNUMINTR(state[0], 25, 0));

            input[7] = (byte)(BITNUMINTR(state[1], 0, 7) | BITNUMINTR(state[0], 0, 6) | BITNUMINTR(state[1], 8, 5) |
                BITNUMINTR(state[0], 8, 4) | BITNUMINTR(state[1], 16, 3) | BITNUMINTR(state[0], 16, 2) |
                BITNUMINTR(state[1], 24, 1) | BITNUMINTR(state[0], 24, 0));

            return input;
        }

        public byte[] desCipher(byte[] input, byte[] output, ulong[] Keys) //zakodowania wiadomości z wykorzystaniem wcześniej wygenerowanego klucza
        {
            uint[] state = new uint[2];
            uint idx, t;

            state = IP(state, input); //przygotowanie wiadomości pkt 1-3

            for (idx = 0; idx < 15; ++idx) 
            {
                t = state[1];
                state[1] = functionF(state[1], Keys[idx]) ^ state[0]; //xor pkt 15
                state[0] = t; //pkt 16
            }

            state[0] = functionF(state[1], Keys[15]) ^ state[0]; //ostanio xor pkt 17

            output = InvIP(state, output);//pkt 18

            return output;

        }
        public byte[] desDecipher(byte[] input, byte[] output, ulong[] Keys)
        {
            uint[] state = new uint[2];
            uint idx, t;

            state = IP(state, input);

            for (idx = 15; idx > 0; idx--)
            {
                t = state[1];
                state[1] = functionF(state[1], Keys[idx]) ^ state[0];
                state[0] = t;
            }

            state[0] = functionF(state[1], Keys[0]) ^ state[0];

            output = InvIP(state, output);

            return output;

        }

    }
}
