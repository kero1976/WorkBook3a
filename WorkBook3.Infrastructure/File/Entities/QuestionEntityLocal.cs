using WorkBook3.Domain.Combo;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Domain.ValueObjects;
using WorkBook3.Infrastructure.File.Core;

namespace WorkBook3.Infrastructure.File.Entities
{
    /// <summary>
    /// ファイル読み書き用QuestionEntity.
    /// </summary>
    /// XMLファイルへのシリアライズ用にすべてpublicのsetter,getterを用意
    public sealed class QuestionEntityLocal : ILocalEntity
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public QuestionEntityLocal()
        {
            _logger.Debug("コンストラクタ");
        }

        /// <summary>
        /// コンストラクタ.QuestionEntityからQuestionEntityLocalを作成する.
        /// </summary>
        /// <param name="entity">エンティティ.</param>
        public QuestionEntityLocal(IQuestionEntity entity)
        {
            _logger.Info("コンストラクタ");
            var entity2 = entity as QuestionEntity;
            this.QestionString = entity2.QuestionString.Value;
            this.Choice = entity2.Choice.Value;
            this.Correct = entity2.Correct.Value;
            this.Explantion = entity2.Explantion;
            this.Group = entity2.Group?.Id ?? 0;
            this.Tag = entity2.Tag;
            this.IsBasic = entity2.IsBasic;
            this.ExamFlg = entity2.ExamFlg;
        }

        /// <summary>
        /// 問題文.
        /// </summary>
        public string QestionString { get; set; }

        /// <summary>
        /// 回答選択肢.
        /// </summary>
        public string Choice { get; set; }

        /// <summary>
        /// 正解.
        /// </summary>
        public string Correct { get; set; }

        /// <summary>
        /// 解説.
        /// </summary>
        public string Explantion { get; set; }

        /// <summary>
        /// グループ.
        /// </summary>
        public int Group { get; set; }

        /// <summary>
        /// タグ.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 基本問題.
        /// </summary>
        public bool? IsBasic { get; set; }

        /// <summary>
        /// 試験問題.
        /// </summary>
        public bool ExamFlg { get; set; }

        /// <summary>
        /// QuestionEntityLocalからQuestionEntityを作成する.
        /// </summary>
        /// <returns>QuestionEntity.</returns>
        public IQuestionEntity GetQuestionEntity()
        {
            return new QuestionEntity(
                new QuestionString(this.QestionString),
                new Choice(this.Choice),
                new Correct(this.Correct, new Choice(this.Choice)),
                this.Explantion,
                GroupCombo.GetGroup(this.Group),
                this.Tag,
                this.IsBasic ?? false,
                this.ExamFlg);
        }
    }
}
