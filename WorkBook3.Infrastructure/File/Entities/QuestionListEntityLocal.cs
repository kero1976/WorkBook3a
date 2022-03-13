using System.Collections.Generic;
using WorkBook3.Domain.Repositories.Entity;
using WorkBook3.Infrastructure.File.Core;

namespace WorkBook3.Infrastructure.File.Entities
{
    /// <summary>
    /// ファイル入出力用ローカルエンティティ.
    /// </summary>
    public class QuestionListEntityLocal : ILocalEntity
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public QuestionListEntityLocal()
        {
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="list">問題文リスト.</param>
        public QuestionListEntityLocal(IQuestionListEntity list)
        {
            ListEntity = new List<QuestionEntityLocal>();
            foreach (var entity in list.GetAllList())
            {
                ListEntity.Add(new QuestionEntityLocal((IQuestionEntity)entity));
            }
        }

        /// <summary>
        /// リスト.
        /// </summary>
        public List<QuestionEntityLocal> ListEntity { get; set; }

        /// <summary>
        /// 変換処理(setterがあるローカルエンティティをgetterのみの公開エンティティに変換する).
        /// </summary>
        /// <returns>問題文リスト.</returns>
        public IQuestionListEntity GetQuestionListEntity()
        {
            List<IQuestionEntity> list = new List<IQuestionEntity>();
            foreach (var data in this.ListEntity)
            {
                list.Add(data.GetQuestionEntity());
            }

            return new Domain.Entities.QuestionListEntity(list);
        }
    }
}
