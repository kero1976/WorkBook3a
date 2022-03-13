using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Domain.ValueObjects;

namespace WorkBook3.Domain.Entities
{
    /// <summary>
    /// 問題エンティティ.
    /// </summary>
    public sealed class QuestionEntity : IQuestionEntity
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="qestionString">問題文.</param>
        /// <param name="choice">回答選択肢.</param>
        /// <param name="correct">正解文.</param>
        /// <param name="explantion">解説.</param>
        /// <param name="group">グループ.</param>
        /// <param name="tag">タグ.</param>
        /// <param name="isBasic">基本問題.</param>
        /// <param name="examFlg">試験問題フラグ.</param>
        public QuestionEntity(QuestionString qestionString, Choice choice, Correct correct, string explantion, Group group, string tag, bool isBasic, bool examFlg)
        {
            _logger.Debug("コンストラクタ");
            this.QuestionString = qestionString;
            this.Choice = choice;
            this.Correct = correct;
            this.Explantion = explantion;
            this.Group = group;
            this.Tag = tag;
            this.IsBasic = isBasic;
            this.ExamFlg = examFlg;
        }

        /// <summary>
        /// 問題文.
        /// </summary>
        public QuestionString QuestionString { get; }

        /// <summary>
        /// 回答選択肢.
        /// </summary>
        public Choice Choice { get; }

        /// <summary>
        /// 正解.
        /// </summary>
        public Correct Correct { get; }

        /// <summary>
        /// 解説.
        /// </summary>
        public string Explantion { get; }

        /// <summary>
        /// グループ.
        /// </summary>
        public Group Group { get; }

        /// <summary>
        /// タグ.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// 基本問題.
        /// </summary>
        public bool IsBasic { get; }

        /// <summary>
        /// 試験問題フラグ.
        /// </summary>
        public bool ExamFlg { get; }

        /// <inheritdoc/>
        public override string GetSearchString()
        {
            return this.QuestionString.Value + this.Explantion + this.Tag;
        }

        /// <inheritdoc/>
        public override string GetValue()
        {
            return this.QuestionString.Value;
        }
    }
}
