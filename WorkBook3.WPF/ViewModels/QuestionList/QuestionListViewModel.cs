using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using WorkBook3.Domain.Combo;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Repositories;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Domain.ValueObjects;
using WorkBook3.Infrastructure.File;
using WorkBook3.WPF.ViewModels.QuestionList.Action;
using WorkBook3.WPF.ViewModels.QuestionRegister;
using WorkBook3.WPF.Views.QuestionRegister;

namespace WorkBook3.WPF.ViewModels
{
    /// <summary>
    /// 一覧画面ViewModel
    /// </summary>
    public class QuestionListViewModel : BindableBase, IDialogAware
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        IQuestionListRepository file;

        internal IQuestionListEntity repo;

        private IDialogService _dialogService;

        private UserComboViewModel<Group> _userCombo = new UserComboViewModel<Group>(new GroupCombo().GetCombo());

        private UserCheckbox3ViewModel _userCheckbox3 = new UserCheckbox3ViewModel();

        private ObservableCollection<IQuestionEntity> _questionList;

        private string _select = string.Empty;
        private string _countText = string.Empty;
        private IQuestionEntity _selectedQuestion;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="file">IQuestionListRepository</param>
        public QuestionListViewModel(IQuestionListRepository file)
            : this(null, file)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dialogService">dialogService</param>
        public QuestionListViewModel(IDialogService dialogService)
            : this(dialogService, new QuestionListFileUnion(@"C:\Users\kero\source\repos\WorkBook2\WorkBook2Test.Tests\テストデータ\Question\結合ファイル読込\ALL.txt"))
        {
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public QuestionListViewModel(IDialogService dialogService, IQuestionListRepository file)
        {
            _logger.Debug("Debug!!");
            _dialogService = dialogService;
            this.file = file;
            repo = file.GetRepository();

            ReLoad = new DelegateCommand(() => QuestionList = new ObservableCollection<IQuestionEntity>(repo.GetAllList()));

            Search = new DelegateCommand(new Search(this).Execute);

            ItemSelect = new DelegateCommand(() => {
                var p = new DialogParameters();
                p.Add(nameof(QuestionRegisterMainViewModel.Entity), SelectedQuestion);
                _dialogService.ShowDialog(nameof(QuestionRegisterMain), p, RegistorClose);
            });

            NewButton = new DelegateCommand(() =>
            {
                _dialogService.ShowDialog(nameof(QuestionRegisterMain), null, RegistorClose);
            });
        }

        public UserCheckbox3ViewModel UserCheckbox3
        {
            get { return _userCheckbox3; }
            set { SetProperty(ref _userCheckbox3, value); }
        }

        /// <summary>
        /// 選択問題.
        /// </summary>
        public UserComboViewModel<Group> UserCombo
        {
            get { return _userCombo; }
            set { SetProperty(ref _userCombo, value); }
        }

        /// <summary>
        /// 選択問題.
        /// </summary>
        public IQuestionEntity SelectedQuestion
        {
            get { return _selectedQuestion; }
            set { SetProperty(ref _selectedQuestion, value); }
        }


        /// <summary>
        /// 問題リスト.
        /// </summary>
        public ObservableCollection<IQuestionEntity> QuestionList
        {
            get { return _questionList; }
            set
            {
                SetProperty(ref _questionList, value);
                CountText = QuestionList.Count + "件";
                UserCombo.SelectedGroup = null;
                UserCheckbox3.IsBasic = false;
                UserCheckbox3.IsExpart = false;
                Select = string.Empty;
            }
        }

        /// <summary>
        /// 表示件数.
        /// </summary>
        public string CountText
        {
            get { return _countText; }
            set { SetProperty(ref _countText, value); }
        }

        /// <summary>
        /// 検索文字.
        /// </summary>
        public string Select
        {
            get { return _select; }
            set { SetProperty(ref _select, value); }
        }

        public DelegateCommand ReLoad { get; }

        /// <inheritdoc/>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title => string.Empty;

        /// <inheritdoc/>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <inheritdoc/>
        public void OnDialogClosed()
        {
        }

        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        /// <summary>
        /// 検索ボタンクリック.
        /// </summary>
        public DelegateCommand Search { get; }

        /// <summary>
        /// 問題ビューダブルクリック.
        /// </summary>
        public DelegateCommand ItemSelect { get; }

        /// <summary>
        /// 新規登録.
        /// </summary>
        public DelegateCommand NewButton { get; }

        private void RegistorClose(IDialogResult dialogResult)
        {
            var type = dialogResult.Parameters.GetValue<string>("type");
            if (type == null)
            {
                return;
            }

            var newEntity = dialogResult.Parameters.GetValue<QuestionEntity>("new");
            if (type.Equals("UPDATE"))
            {
                var oldEntity = dialogResult.Parameters.GetValue<QuestionEntity>("old");
                repo.UpdateQuestion(oldEntity, newEntity);
            }

            if (type.Equals("INSERT"))
            {
                repo.AddQuestion(newEntity);
            }

            file.SaveRepository(repo);
            repo = file.GetRepository();
            ReLoad.Execute();
        }
    }
}
