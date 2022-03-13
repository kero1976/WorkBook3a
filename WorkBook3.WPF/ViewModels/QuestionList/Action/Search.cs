using System.Collections.ObjectModel;
using System.Linq;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Repositories.Entity;

namespace WorkBook3.WPF.ViewModels.QuestionList.Action
{
    /// <summary>
    /// 検索実行処理.
    /// </summary>
    internal class Search
    {
        private readonly QuestionListViewModel vm;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="vm">ViewModel</param>
        public Search(QuestionListViewModel vm)
        {
            this.vm = vm;
        }

        /// <summary>
        /// 実行処理.
        /// </summary>
        internal void Execute()
        {
            var list = vm.repo.GetAllList().Cast<QuestionEntity>();

            vm.QuestionList = new ObservableCollection<IQuestionEntity>(
            list.Where(d => d.GetSearchString().IndexOf(vm.Select) != -1)
            .Where(d => (vm.UserCombo.SelectedGroup == null) || d.Group == vm.UserCombo.SelectedGroup)
            .Where(d => !vm.UserCheckbox3.IsBasic || d.IsBasic)
            .Where(d => !vm.UserCheckbox3.IsExpart || !d.IsBasic)
            .Where(d => !vm.UserCheckbox3.ExamFlg || d.ExamFlg));
        }
    }
}
