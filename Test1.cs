using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bsk_zadania1
{
    [TestClass]
    public class Test1
    {
        public Rail Rail = new Rail();
        public Macierzowe2a macierzowe2 = new Macierzowe2a();
        public Form2 macierzowa2b = new Form2();
        public LFSR lfsr = new LFSR();
        public SzyfrowanieStrumieniowe szyfrowanieStrumieniowe = new SzyfrowanieStrumieniowe();
        public Des des = new Des();
        [TestMethod]
        public void TestRailEncrypt()
        {
            string word = Rail.RailEncrypt(2, "abcde"); 
            Assert.AreEqual("acebd", word);
            word = Rail.RailEncrypt(3, "abcdefg");
            Assert.AreEqual("aebdfcg", word);
        }
        [TestMethod]
        public void TestRailDecrypt()
        {
            string word = Rail.RailDecrupt(2, "acebd");
            Assert.AreEqual("abcde", word);
            word = Rail.RailDecrupt(3, "aebdfcg");
            Assert.AreEqual("abcdefg", word);
        }
        [TestMethod]
        public void TestMacierzowa2aEnrypt()
        {
            string word = macierzowe2.macierzowa2aEncrypt("abcdefg");
            Assert.AreEqual("cdaebfg",word);
            word = macierzowe2.macierzowa2aEncrypt("kasztanowiec");
            Assert.AreEqual("szktaowainec", word);
        }
        [TestMethod]
        public void TestMacierzowa2aDecrypt()
        {
            string word = macierzowe2.macierzowa2aDecrypt("cdaebfg");
            Assert.AreEqual("abcdefg", word);
            word = macierzowe2.macierzowa2aDecrypt("szktaowainec");
            Assert.AreEqual("kasztanowiec", word);
        }
        [TestMethod]
        public void TestMacierzowa2bEncrypt()
        {
            string word = macierzowa2b.Encrypt("abcd","zba");
            Assert.AreEqual("cbad", word);
            word = macierzowa2b.Encrypt("Halotojestwiadomosc", "klucz");
            Assert.AreEqual("osdcHowmajioleastto", word);
        }
        [TestMethod]
        public void TestMacierzowa2bDecrypt()
        {
            string word = macierzowa2b.Decrypt("abcd", "zba");
            Assert.AreEqual("cbad", word);
            word = macierzowa2b.Decrypt("HECRNCEYIISEPSGDIRNTOAAESRMPNSSROEEBTETIAEEHS", "CONVENIENCE");
            Assert.AreEqual("HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION", word);
        }
        [TestMethod]
        public void TestLFSR()
        {
            lfsr.Initialize("1-4");
            ulong word = lfsr.Iteration(Convert.ToUInt64(9)); //9=1001
            Assert.AreEqual(word, Convert.ToUInt64(4)); //after xor 1001 => 0100=4
            lfsr.Initialize("1-2-5");
            word = lfsr.Iteration(Convert.ToUInt64(10)); //10=01010
            Assert.AreEqual(word, Convert.ToUInt64(21)); //after xor 01010 => 10101=21
        }
        [TestMethod]
        public void TestStrumieniowe()
        {
            szyfrowanieStrumieniowe.lfsr.Initialize("1-4");
            byte[] vs = Encoding.ASCII.GetBytes("Halo");
            byte[] code = szyfrowanieStrumieniowe.XorOperation(vs);
            Assert.AreEqual("Halo", System.Text.Encoding.UTF8.GetString(szyfrowanieStrumieniowe.XorOperation(code)));
            szyfrowanieStrumieniowe.lfsr.Initialize("1-4-5-10");
            vs = Encoding.ASCII.GetBytes("Dzien dobry to ja student");
            code = szyfrowanieStrumieniowe.XorOperation(vs);
            Assert.AreEqual("Dzien dobry to ja student", System.Text.Encoding.UTF8.GetString(szyfrowanieStrumieniowe.XorOperation(code)));
        }
        [TestMethod]
        public void TestDesPC1()
        {
            ulong i = 1383827165325090801;
            // i w systemie dwójkowym "00010011 00110100 01010111 01111001 10011011 10111100 11011111 11110001";
            ulong r = 67779029043144591;
            // r w systemie dwójkowym "1111000 0110011 0010101 0101111 0101010 1011001 1001111 0001111";
            ulong result =des.preparekey1(i);
            Console.WriteLine(result);
            //permutedChoice1
            Assert.AreEqual(r, result);
        }
        [TestMethod]
        public void TestDesKey()
        {
            ulong i = 1383827165325090801;
            // i w systemie dwójkowym "00010011 00110100 01010111 01111001 10011011 10111100 11011111 11110001";
            ulong firstK = 29699430183026; //000110 110000 001011 101111 111111 000111 000001 110010    11110011010111011011001110110111100100011100101
            ulong lastK = 223465186400245; //110010 110011 110110 001011 000011 100001 011111 110101
            ulong[] keyCipher = new ulong[16];
            des.generateKey(i, keyCipher);
            Assert.AreEqual(keyCipher[0], firstK);
            Assert.AreEqual(keyCipher[15],lastK);
        }
        [TestMethod]
        public void TestDesIP()
        {
            string hex = "0123456789ABCDEF";
            byte[] input = new byte[8];
            input = Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
            uint[] state = new uint[2];
            uint output1 = 3422604543; //1100 1100 0000 0000 1100 1100 1111 1111
            uint output2 = 4037734570; //1111 0000 1010 1010 1111 0000 1010 1010
            des.IP(state, input);
            Assert.AreEqual(output1, state[0]);
            Assert.AreEqual(output2, state[1]);
        }
        [TestMethod]
        public void TestDesF()
        {
            ulong key = 29699430183026;
            uint R = 4037734570;
            uint output=des.functionF(R, key);
            uint testout = 592095675;
            Assert.AreEqual(testout, output);
            Console.WriteLine(output);
        }
        [TestMethod]
        public void TestCryptDes()
        {
            string hex = "0123456789ABCDEF";
            byte[] input = new byte[8];
            byte[] output = new byte[8];
            input = Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
            ulong[] keyCipher = new ulong[16];
            ulong key = 1383827165325090801;
            string testOut = "85E813540F0AB405";
            des.generateKey(key, keyCipher);
            des.desCipher(input,output,keyCipher);
            string o = BitConverter.ToString(output).Replace("-", string.Empty);
            Assert.AreEqual(testOut, o);
        }
        [TestMethod]
        public void TestDecryptDes()
        {
            string hex = "85E813540F0AB405";
            byte[] input = new byte[8];
            byte[] output = new byte[8];
            input = Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
            ulong[] keyCipher = new ulong[16];
            ulong key = 1383827165325090801;
            des.generateKey(key, keyCipher);
            string testOut = "0123456789ABCDEF";
            des.desDecipher(input,output,keyCipher);
            string o = BitConverter.ToString(output).Replace("-", string.Empty);
            Assert.AreEqual(testOut, o);
        }
    }
}
