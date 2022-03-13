using WorkBook3.Domain.Entities;
using WorkBook3.Domain.ValueObjects;

namespace WorkBook3Test.Tests.Helpers.EntityHelpers
{
    public class QuestionEntityHelper
    {
        public static  QuestionEntity CreateEntity(string str)
        {
            return new QuestionEntity(
                new QuestionString(str),
                new Choice("1.A 2.B 3.C 4.D"),
                new Correct("1"),
                "解説",
                new Group(1, "A", Category.BUSINESS),
                string.Empty,
                false,
                false);
        }

    }
}
