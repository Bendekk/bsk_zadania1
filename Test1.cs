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
        [TestMethod]
        public void TestRail()
        {
            string word = Rail.RailEncrypt(2, "abcde");
            Console.Write(word);    
            Assert.AreEqual("acebd", word);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("a","a");
        }
    }
}
