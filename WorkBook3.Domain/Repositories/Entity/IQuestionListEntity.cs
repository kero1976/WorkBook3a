using System.Collections.Generic;

namespace WorkBook3.Domain.Repositories.Entity
{
    /// <summary>
    /// 問題リストインタフェース.
    /// </summary>
    public abstract class IQuestionListEntity : IEntity
    {
        /// <summary>
        /// 問題リストを返す.
        /// </summary>
        /// <returns>問題リスト.</returns>
        public abstract List<IQuestionEntity> GetAllList();

        /// <summary>
        /// 問題件数を返す.
        /// </summary>
        /// <returns>問題件数.</returns>
        public abstract int Count();

        /// <summary>
        /// 問題の追加.
        /// </summary>
        /// <param name="newentity">追加する問題.</param>
        public abstract void AddQuestion(IQuestionEntity newentity);

        /// <summary>
        /// 問題の更新.
        /// </summary>
        /// <param name="oldentity">修正前の問題.</param>
        /// <param name="newentity">修正後の問題.</param>
        public abstract void UpdateQuestion(IQuestionEntity oldentity, IQuestionEntity newentity);
    }
}
