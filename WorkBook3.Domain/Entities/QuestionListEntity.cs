using System.Collections.Generic;
using WorkBook3.Domain.Repositories.Entity;

namespace WorkBook3.Domain.Entities
{
    /// <summary>
    /// 問題文リスト.
    /// </summary>
    public class QuestionListEntity : IQuestionListEntity
    {
        private readonly List<IQuestionEntity> list;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="list">問題文リスト.</param>
        public QuestionListEntity(List<IQuestionEntity> list)
        {
            this.list = list;
        }

        /// <summary>
        /// 取得したデータの件数を返す.
        /// </summary>
        /// <returns>取得件数.</returns>
        public override int Count()
        {
            return this.list.Count;
        }

        /// <inheritdoc/>
        public override List<IQuestionEntity> GetAllList()
        {
            return list;
        }

        /// <inheritdoc/>
        public override void UpdateQuestion(IQuestionEntity oldentity, IQuestionEntity newentity)
        {
            list.Remove(oldentity);
            list.Add(newentity);
        }

        /// <inheritdoc/>
        public override void AddQuestion(IQuestionEntity newentity)
        {
            list.Add(newentity);
        }

        /// <inheritdoc/>
        public override string GetValue()
        {
            return string.Empty;
        }
    }
}
