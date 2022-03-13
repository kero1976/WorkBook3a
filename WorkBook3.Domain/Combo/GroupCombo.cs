using System;
using System.Collections.ObjectModel;
using WorkBook3.Domain.Exceptions;
using WorkBook3.Domain.Repositories.Combo;
using WorkBook3.Domain.ValueObjects;

namespace WorkBook3.Domain.Combo
{
    /// <summary>
    /// グループコンボ.
    /// </summary>
    public sealed class GroupCombo : ICombo<Group>
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// IDからグループを取得.
        /// </summary>
        /// <param name="id">番号.</param>
        /// <returns>グループ.</returns>
        public static Group GetGroup(int id)
        {
            _logger.Debug("id:{0}", id);
            GroupCombo my = new GroupCombo();
            var list = my.GetCombo();
            try
            {
                return list[id];
            }
            catch (Exception e)
            {
                _logger.Debug(e, "Groupの取得に失敗");
                throw new DataParseException("Groupの解析に失敗", e);
            }
        }

        /// <summary>
        /// 問題グループコンボの取得.
        /// </summary>
        /// <returns>問題グループのコンボ用リスト.</returns>
        public ObservableCollection<Group> GetCombo()
        {
            _logger.Debug("グループコンボを取得");
            ObservableCollection<Group> list = new ObservableCollection<Group>
            {
                new Group(0, "未設定", Category.UNKNOWN),
                new Group(1, "次世代ビジネストレンド	", Category.BUSINESS),
                new Group(2, "戦略・理論　(思想としてのIT)", Category.BUSINESS),
                new Group(3, "業務　(仕組みとしてのIT)", Category.BUSINESS),
                new Group(4, "商品　(商品としてのIT)", Category.BUSINESS),
                new Group(5, "サービス　(サービスとしてのIT)", Category.BUSINESS),
                new Group(6, "IT機器　(道具としてのIT)", Category.BUSINESS),

                new Group(7, "ロボットとスマートマシーン", Category.IT),
                new Group(8, "AI(人工知能)", Category.IT),
                new Group(9, "IoT(モノのインターネット)", Category.IT),
                new Group(10, "ビッグデータとデータサイエンス", Category.IT),
                new Group(11, "クラウドコンピューティングと開発/運用	", Category.IT),
                new Group(12, "サイバーセキュリティ", Category.IT),
            };

            return list;
        }
    }
}
