using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBook3.Domain.Helpers;

namespace WorkBook3Test.Tests.Helpers.PaddingHelpers
{
    public class PaddingHelperTest : TestBase
    {
        public PaddingHelperTest() : base(string.Empty)
        {

        }

        [Test]
        public void 基本形()
        {
            Assert.AreEqual("1001", PaddingHelper.GetData("1",1,4));
            Assert.AreEqual("2001", PaddingHelper.GetData("2", 1, 4));
            Assert.AreEqual("1002", PaddingHelper.GetData("1", 2, 4));
        }

        [Test]
        public void サイズ1byte()
        {
            Assert.AreEqual("3", PaddingHelper.GetData("1", 3, 1));
            Assert.AreEqual("3", PaddingHelper.GetData("2", 3, 1));
            Assert.AreEqual("4", PaddingHelper.GetData("1", 54, 1));
            Assert.AreEqual("3", PaddingHelper.GetData("1", 123, 1));
        }
    }
}
