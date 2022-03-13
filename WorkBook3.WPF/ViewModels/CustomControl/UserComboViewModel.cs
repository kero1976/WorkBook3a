using Prism.Mvvm;
using System.Collections.ObjectModel;
using WorkBook3.Domain.Repositories.Combo;

namespace WorkBook3.WPF.ViewModels
{
    /// <summary>
    /// コンボボックスViewModel.
    /// </summary>
    /// <typeparam name="T">コンボアイテム.</typeparam>
    public class UserComboViewModel<T> : BindableBase
        where T : IComboItem
    {
        private ObservableCollection<T> _groupList = null;
        private T _selectedGroup;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="list">コンボリスト.</param>
        public UserComboViewModel(ObservableCollection<T> list)
        {
            _groupList = list;
        }

        /// <summary>
        /// グループコンボ.
        /// </summary>
        public ObservableCollection<T> GroupList
        {
            get { return _groupList; }
            set { SetProperty(ref _groupList, value); }
        }

        /// <summary>
        /// 選択グループ.
        /// </summary>
        public T SelectedGroup
        {
            get { return _selectedGroup; }
            set { SetProperty(ref _selectedGroup, value); }
        }
    }
}
