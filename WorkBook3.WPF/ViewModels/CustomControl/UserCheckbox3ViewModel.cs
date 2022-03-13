using Prism.Mvvm;

namespace WorkBook3.WPF.ViewModels
{
    /// <summary>
    /// チェックボックス3個セット
    /// </summary>
    public class UserCheckbox3ViewModel : BindableBase
    {
        private bool _isBasic = false;
        private bool _isExpart = false;
        private bool _examFlg = false;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public UserCheckbox3ViewModel()
        {
        }

        /// <summary>
        /// 基礎問題.
        /// </summary>
        public bool IsBasic
        {
            get { return _isBasic; }
            set { SetProperty(ref _isBasic, value); }
        }

        /// <summary>
        /// 応用問題.
        /// </summary>
        public bool IsExpart
        {
            get { return _isExpart; }
            set { SetProperty(ref _isExpart, value); }
        }

        /// <summary>
        /// 応用問題.
        /// </summary>
        public bool ExamFlg
        {
            get { return _examFlg; }
            set { SetProperty(ref _examFlg, value); }
        }
    }
}
