using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Repositories;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Infrastructure.File;
using WorkBook3Test.Tests.Helpers.EntityHelpers;

namespace WorkBook3Test.Tests.Infrastructure.File
{
    public class QuestionListFileUnion2Test : TestBase
    {
        public QuestionListFileUnion2Test() : base("Infrastructure/QuestionListFileUnion2Test")
        {
        }

        [Test]
        public void 読込テスト()
        {
            IQuestionListRepository file = new QuestionListFileUnion(GetTestFile("データ1/All.txt"));
            var repo = file.GetRepository();
            Assert.IsNotNull(repo);
            Assert.AreEqual(319, repo.Count());
        }

        [Test]
        public void 書込テスト()
        {
            IQuestionListRepository file = new QuestionListFileUnion(GetTestFile("データ2/All.txt"));
            List<IQuestionEntity> list = new List<IQuestionEntity>
            {
                QuestionEntityHelper.CreateEntity("A"),
                QuestionEntityHelper.CreateEntity("B"),
                QuestionEntityHelper.CreateEntity("C"),
            };
            IQuestionListEntity entity = new QuestionListEntity(list);
            try
            {
                file.SaveRepository(entity);
            }catch(Exception )
            {
                Assert.Fail();
            }
            
            
        }
    }
}
