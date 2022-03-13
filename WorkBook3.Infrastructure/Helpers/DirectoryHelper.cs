using System;
using System.IO;
using WorkBook3.Domain.Exceptions;
using WorkBook3.Domain.Helpers;

namespace WorkBook3.Infrastructure.Helpers
{
    /// <summary>
    /// ディレクトリヘルパー.
    /// </summary>
    public static class DirectoryHelper
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// ディレクトリ作成.
        /// </summary>
        /// <param name="filePath">ファイルパス.</param>
        public static void CreateDirectory(string filePath)
        {
            _logger.Debug("処理開始:{0}", filePath);
            var dirPath = FilePathHelper.GetDirName(filePath);

            if (Directory.Exists(dirPath))
            {
                _logger.Debug("フォルダが存在します。{0}", dirPath);
            }
            else
            {
                _logger.Debug("フォルダを作成します。{0}", dirPath);
                try
                {
                    Directory.CreateDirectory(dirPath);
                }
                catch (Exception e)
                {
                    _logger.Error(e, "フォルダ作成に失敗しました。:" + dirPath);
                    throw new FileException("フォルダ作成に失敗しました。:" + dirPath, e);
                }
            }

            _logger.Debug("処理終了");
        }
    }
}
