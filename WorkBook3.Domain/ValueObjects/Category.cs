namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// カテゴリ.
    /// </summary>
    public sealed class Category : ValueObject<Category>
    {
        /// <summary>
        /// ビジネストレンド(総合).
        /// </summary>
        public static readonly Category BUSINESS = new Category("ビジネストレンド(総合)");

        /// <summary>
        /// IT技術(総合).
        /// </summary>
        public static readonly Category IT = new Category("IT技術(総合)");

        /// <summary>
        /// 不明.
        /// </summary>
        public static readonly Category UNKNOWN = new Category("不明");

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="name">カテゴリ名.</param>
        private Category(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// カテゴリ名.
        /// </summary>
        public string Name { get; }

        /// <inheritdoc/>
        protected override bool EqualsCore(Category other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
