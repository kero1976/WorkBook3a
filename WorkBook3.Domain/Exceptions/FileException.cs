using System;

namespace WorkBook3.Domain.Exceptions
{
    /// <summary>
    /// ファイルException.
    /// </summary>
    public sealed class FileException : Exception
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly Exception _e;

        /// <summary>
        /// ファイルException.
        /// </summary>
        /// <param name="message">メッセージ.</param>
        /// <param name="e">元となった例外.</param>
        public FileException(string message, Exception e)
            : base(message)
        {
            _e = e;
            _logger.Error(_e);
        }
    }
}
