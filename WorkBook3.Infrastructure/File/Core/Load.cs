using System;
using WorkBook3.Domain.Exceptions;

namespace WorkBook3.Infrastructure.File.Core
{
    /// <summary>
    /// ILocalEntityを実装したクラスをXMLファイルから読み込む.
    /// </summary>
    /// <typeparam name="T">ILocalEntityを実装したクラス.</typeparam>
    internal class Load<T>
        where T : ILocalEntity
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 読込処理.
        /// </summary>
        /// <param name="filePath">ファイルパス.</param>
        /// <returns>エンティティ.</returns>
        public static T Execute(string filePath)
        {
            _logger.Debug("データ取得:{0}", filePath);
            T obj;
            try
            {
                // XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(T));

                // 読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    filePath, new System.Text.UTF8Encoding(false));

                // XMLファイルから読み込み、逆シリアル化する
                obj = (T)serializer.Deserialize(sr);

                // ファイルを閉じる
                sr.Close();
            }
            catch (Exception e)
            {
                _logger.Error(e, "データ取得に失敗:" + filePath);
                throw new FileException("ファイルの読込に失敗:" + filePath, e);
            }

            _logger.Debug("処理正常終了");
            return obj;
        }
    }
}
