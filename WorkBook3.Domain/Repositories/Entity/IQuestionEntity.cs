namespace WorkBook3.Domain.Repositories.Entity
{
    /// <summary>
    /// 問題インタフェース.
    /// </summary>
    public abstract class IQuestionEntity : IEntity
    {
        /// <summary>
        /// 検索対象文字列の取得.
        /// </summary>
        /// <returns>検索対象文字列.</returns>
        public abstract string GetSearchString();
    }
}
