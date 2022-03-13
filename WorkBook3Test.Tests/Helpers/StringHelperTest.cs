using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBook3.Domain.Helpers;

namespace WorkBook3Test.Tests.Helpers
{
    public class StringHelperTest : TestBase
    {
        public StringHelperTest() : base(string.Empty)
        {

        }

        [Test]
        public void List取得()
        {
            Assert.AreEqual(3, StringHelper.GetList("1,A\n2,B\n3,C").Count);
            Assert.AreEqual(2, StringHelper.GetList("1,A\n2,B\n").Count);
        }
    }
}
