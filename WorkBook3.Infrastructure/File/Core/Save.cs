using System;
using WorkBook3.Domain.Exceptions;

namespace WorkBook3.Infrastructure.File.Core
{
    /// <summary>
    /// ILocalEntityを実装したクラスをXMLファイルに書き込む.
    /// </summary>
    /// <typeparam name="T">ILocalEntityを実装したクラス.</typeparam>
    internal class Save<T>
        where T : ILocalEntity
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 保存処理.
        /// </summary>
        /// <param name="entity">エンティティ.</param>
        /// <param name="filePath">ファイル名.</param>
        public static void Execute(T entity, string filePath)
        {
            _logger.Debug("データ保存:{0}, filePath={1}", entity.ToString(), filePath);
            try
            {
                // XmlSerializerオブジェクトを作成
                // オブジェクトの型を指定する
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));

                // 書き込むファイルを開く（UTF-8 BOM無し）
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                   filePath, false, new System.Text.UTF8Encoding(false));

                // シリアル化し、XMLファイルに保存する
                serializer.Serialize(sw, entity);

                // ファイルを閉じる
                sw.Close();
            }
            catch (Exception e)
            {
                _logger.Error(e, "ファイルの保存に失敗:path={0},entity={1}", filePath, entity);
                throw new FileException("ファイルの保存に失敗", e);
            }

            _logger.Debug("処理正常終了");
        }
    }
}
