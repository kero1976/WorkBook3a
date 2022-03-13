using Prism.Mvvm;
using WorkBook3.Domain.Entities;

namespace WorkBook3.WPF.ViewModels.QuestionRegister
{
    /// <summary>
    /// 基本項目.
    /// </summary>
    public class UserBasicEntityViewModel : BindableBase
    {
        private string _correctString = string.Empty;
        private string _explantion = string.Empty;
        private string _questionString = string.Empty;
        private string _choiceString = string.Empty;

        /// <summary>
        /// 問題.
        /// </summary>
        public string QuestionString
        {
            get { return _questionString; }
            set { SetProperty(ref _questionString, value); }
        }

        /// <summary>
        /// 回答選択肢.
        /// </summary>
        public string ChoiceString
        {
            get { return _choiceString; }
            set { SetProperty(ref _choiceString, value); }
        }

        /// <summary>
        /// 正解.
        /// </summary>
        public string CorrectString
        {
            get { return _correctString; }
            set { SetProperty(ref _correctString, value); }
        }

        /// <summary>
        /// 解説.
        /// </summary>
        public string Explantion
        {
            get { return _explantion; }
            set { SetProperty(ref _explantion, value); }
        }

        /// <summary>
        /// 値のセット.
        /// </summary>
        /// <param name="entity">entity</param>
        public void SetBasicEntity(QuestionEntity entity)
        {
            QuestionString = entity.QuestionString.Value;
            ChoiceString = entity.Choice.DisplayValue;
            CorrectString = entity.Correct.Value;
            Explantion = entity.Explantion;
        }
    }
}
