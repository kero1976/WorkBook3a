using WorkBook3.Domain.Repositories.Combo;

namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// 問題グループ.
    /// </summary>
    /// 1～12のグループがあり、それぞれのグループは2つのカテゴリに属する
    public class Group : ValueObject<Group>, IComboItem
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="name">名称.</param>
        /// <param name="category">カテゴリ.</param>
        public Group(int id, string name, Category category)
        {
            this.Id = id;
            this.Name = name;
            this.CategoryName = category;
        }

        /// <summary>
        /// ID.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// グループ名.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// カテゴリ名.
        /// </summary>
        public Category CategoryName { get; }

        /// <summary>
        /// 表示用名称.
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return this.Id + "." + this.Name;
            }
        }

        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return this.DisplayValue;
        }

        /// <summary>
        /// ソート用.
        /// </summary>
        /// <param name="obj">比較対象</param>
        /// <returns>結果</returns>
        public int CompareTo(object obj)
        {
            _logger.Debug("ソートを行います");
            Group ia = obj as Group;

            if (ia.Id < this.Id)
            {
                return -1;
            }

            if (ia.Id == this.Id)
            {
                return 0;
            }

            return 1;
        }

        /// <inheritdoc/>
        protected override bool EqualsCore(Group other)
        {
            return this.Id == other.Id;
        }
    }
}
