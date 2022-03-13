using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using WorkBook3.Domain.Combo;
using WorkBook3.Domain.Entities;
using WorkBook3.WPF.ViewModels.QuestionRegister;
using WorkBook3.WPF.Views.QuestionRegister;

namespace WorkBook3.WPF.ViewModels
{
    /// <summary>
    /// MainWindowViewModel.
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        private IDialogService _dialogService;

        private string _title = "Prism Application";

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="dialogService">dialogService</param>
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _logger.Debug("Debug!!");
            ListView = new DelegateCommand(() => _dialogService.ShowDialog(nameof(QuestionList), null, null));
            FixDataCreate = new DelegateCommand(() => _dialogService.ShowDialog(nameof(FixDataCreate), null, null));
            OneView = new DelegateCommand(() =>
            {
                var p = new DialogParameters();
                QuestionEntity selectedQuestion = new QuestionEntity(
                    new Domain.ValueObjects.QuestionString("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"),
                    new Domain.ValueObjects.Choice("1.a 2.b 3.c 4.d"),
                    new Domain.ValueObjects.Correct("1"),
                    "A",
                    GroupCombo.GetGroup(1),
                    "A",
                    false,
                    false);
                p.Add(nameof(QuestionRegisterMainViewModel.Entity), selectedQuestion);
                _dialogService.ShowDialog(nameof(QuestionRegisterMain), p, null);
            });
        }

        /// <summary>
        /// タイトル.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// 一覧画面.
        /// </summary>
        public DelegateCommand ListView { get; }

        /// <summary>
        /// 詳細画面.
        /// </summary>
        public DelegateCommand OneView { get; }

        /// <summary>
        /// 固定長データ作成画面.
        /// </summary>
        public DelegateCommand FixDataCreate { get; }
    }
}
