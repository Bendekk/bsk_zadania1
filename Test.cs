using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace bsk_zadania1
{
    public class Test
    {
        private Rail Rail = new Rail();
        [Test]
        public void TestRail()
        {
            Assert.AreEqual("acebd", Rail.RailDecrupt(2, "abcde"));
        }
    }
}
