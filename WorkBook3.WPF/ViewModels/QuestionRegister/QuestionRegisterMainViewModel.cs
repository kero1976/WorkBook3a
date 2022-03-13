using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using WorkBook3.Domain.Combo;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Domain.ValueObjects;
using WorkBook3.WPF.ViewModels.QuestionRegister;

namespace WorkBook3.WPF.ViewModels.QuestionRegister
{
    /// <summary>
    /// 登録画面.
    /// </summary>
    public class QuestionRegisterMainViewModel : BindableBase, IDialogAware
    {
        private bool _isBasic = false;
        private bool _examFlg = false;

        private string _tag = string.Empty;
        private UserComboViewModel<Group> _userCombo = new UserComboViewModel<Group>(new GroupCombo().GetCombo());

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public QuestionRegisterMainViewModel()
        {
            
            Register = new DelegateCommand(() =>
            {
                var p = new DialogParameters();
                if (Entity == null)
                {
                    p.Add("type", "INSERT");
                }
                else
                {
                    p.Add("type", "UPDATE");
                    p.Add("old", Entity);
                }

                p.Add("new", new QuestionEntity(new QuestionString(_userBasicEntity.QuestionString), new Choice(_userBasicEntity.ChoiceString), new Correct(_userBasicEntity.CorrectString), _userBasicEntity.Explantion, UserCombo.SelectedGroup, Tag, IsBasic, ExamFlg));
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
            });
        }

        /// <summary>
        /// クローズイベント.
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 登録ボタン.
        /// </summary>
        public DelegateCommand Register { get; }

        /// <summary>
        /// 問題エンティティ.
        /// </summary>
        public IQuestionEntity Entity { get; set; }




        private UserBasicEntityViewModel _userBasicEntity = new UserBasicEntityViewModel();
        public UserBasicEntityViewModel UserBasicEntity
        {
            get { return _userBasicEntity; }
            set { SetProperty(ref _userBasicEntity, value); }
        }

        /// <summary>
        /// グループコンボ.
        /// </summary>
        public UserComboViewModel<Group> UserCombo
        {
            get { return _userCombo; }
            set { SetProperty(ref _userCombo, value); }
        }

        /// <summary>
        /// 基本問題.
        /// </summary>
        public bool IsBasic
        {
            get { return _isBasic; }
            set { SetProperty(ref _isBasic, value); }
        }

        /// <summary>
        /// 基本問題.
        /// </summary>
        public bool ExamFlg
        {
            get { return _examFlg; }
            set { SetProperty(ref _examFlg, value); }
        }

        /// <summary>
        /// タグ.
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { SetProperty(ref _tag, value); }
        }

        /// <summary>
        /// 画面タイトル.
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
            if (parameters != null)
            {
                Entity = parameters.GetValue<IQuestionEntity>(nameof(Entity));
                var entity2 = Entity as QuestionEntity;
                if (entity2 != null)
                {
                    UserCombo.SelectedGroup = entity2.Group;

                    _userBasicEntity.SetBasicEntity(entity2);
                    IsBasic = entity2.IsBasic;
                    Tag = entity2.Tag;
                    ExamFlg = entity2.ExamFlg;
                }
            }
        }
    }
}
