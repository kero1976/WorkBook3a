namespace WorkBook3.Domain.Repositories
{
    /// <summary>
    /// リポジトリインタフェース.
    /// </summary>
    /// <typeparam name="T">エンティティ.</typeparam>
    public interface IRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// データ取得.
        /// </summary>
        /// <returns>データ.</returns>
        T GetRepository();

        /// <summary>
        /// データ保存.
        /// </summary>
        /// <param name="entity">エンティティ.</param>
        void SaveRepository(T entity);
    }
}
