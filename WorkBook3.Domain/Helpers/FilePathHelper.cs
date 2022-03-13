using System.IO;

namespace WorkBook3.Domain.Helpers
{
    /// <summary>
    /// ファイルパスヘルパー.
    /// </summary>
    public static class FilePathHelper
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 指定されたファイルパスの絶対パスのフォルダ名を取得する.
        /// </summary>
        /// <param name="filePath">ファイルパス.</param>
        /// <returns>絶対パスのフォルダ.</returns>
        public static string GetDirName(string filePath)
        {
            _logger.Debug("処理開始：{0}", filePath);
            var result = Path.GetDirectoryName(GetFullPath(filePath));
            _logger.Debug("処理終了：{0}", result);
            return result;
        }

        /// <summary>
        /// 指定されたファイルパスの絶対パスを取得する.
        /// </summary>
        /// <param name="filePath">ファイルパス.</param>
        /// <returns>絶対パス.</returns>
        public static string GetFullPath(string filePath)
        {
            _logger.Debug("処理開始：{0}", filePath);
            var result = Path.GetFullPath(filePath);
            _logger.Debug("処理終了：{0}", result);
            return result;
        }
    }
}
