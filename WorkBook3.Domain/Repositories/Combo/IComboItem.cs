namespace WorkBook3.Domain.Repositories.Combo
{
    /// <summary>
    /// コンボ要素のインタフェース
    /// </summary>
    public interface IComboItem
    {
        /// <summary>
        /// 識別するためのID.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 画面に表示する文字列.
        /// </summary>
        string DisplayValue { get; }
    }
}
