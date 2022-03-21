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
    }
}
