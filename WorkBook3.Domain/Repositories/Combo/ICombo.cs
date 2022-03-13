using System.Collections.ObjectModel;

namespace WorkBook3.Domain.Repositories.Combo
{
    /// <summary>
    /// コンボ用インタフェース。
    /// </summary>
    /// <typeparam name="T">コンボ内の要素クラス</typeparam>
    public interface ICombo<T>
        where T : IComboItem
    {
        /// <summary>
        /// コンボのリストを取得する.
        /// </summary>
        /// <returns>コンボのリスト</returns>
        ObservableCollection<T> GetCombo();
    }
}
