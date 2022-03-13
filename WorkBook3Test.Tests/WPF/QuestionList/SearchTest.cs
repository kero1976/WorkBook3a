using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBook3.Infrastructure.File;
using WorkBook3.WPF.ViewModels;

namespace WorkBook3Test.Tests.WPF.QuestionList
{
    public class SearchTest : TestBase
    {
        public SearchTest() : base("WPF")
        {

        }

        [Test]
        public void 全件検索()
        {
            QuestionListFileUnion file = new QuestionListFileUnion(GetTestFile("ALL.txt"));
            QuestionListViewModel vm = new QuestionListViewModel(file);
            vm.Search.Execute();
            Assert.AreEqual("319件", vm.CountText);
        }
    }
}
