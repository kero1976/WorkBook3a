using WorkBook3.Domain.Repositories;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Infrastructure.File.Core;
using WorkBook3.Infrastructure.File.Entities;
using WorkBook3.Infrastructure.Helpers;

namespace WorkBook3.Infrastructure.File
{
    /// <summary>
    /// 問題リストの結合ファイル版リポジトリ.
    /// </summary>
    public class QuestionListFileUnion : IQuestionListRepository
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="filePath">ファイルパス.</param>
        public QuestionListFileUnion(string filePath)
        {
            this.FilePath = filePath;
        }

        private string FilePath { get; }

        /// <inheritdoc/>
        public IQuestionListEntity GetRepository()
        {
            _logger.Debug("処理開始:{0}", this.FilePath);
            var obj = Load<QuestionListEntityLocal>.Execute(this.FilePath);
            _logger.Debug("処理正常終了");
            return obj.GetQuestionListEntity();
        }

        /// <inheritdoc/>
        public void SaveRepository(IQuestionListEntity entity)
        {
            _logger.Debug("データ保存:{0}, filePath={1}", entity.ToString(), this.FilePath);
            DirectoryHelper.CreateDirectory(this.FilePath);
            Save<QuestionListEntityLocal>.Execute(new QuestionListEntityLocal(entity), this.FilePath);
            _logger.Debug("処理正常終了");
        }
    }
}
