using System;

namespace WorkBook3.Domain.Exceptions
{
    /// <summary>
    /// データ解析Exception.
    /// </summary>
    public sealed class DataParseException : Exception
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly Exception _e;

        /// <summary>
        /// データ解析Exception.
        /// </summary>
        /// <param name="message">メッセージ.</param>
        /// <param name="e">元となった例外.</param>
        public DataParseException(string message, Exception e)
            : base(message)
        {
            this._e = e;
            _logger.Error(_e);
        }

        /// <summary>
        /// データ解析Exception.
        /// </summary>
        /// <param name="message">メッセージ.</param>
        public DataParseException(string message)
            : base(message)
        {
        }
    }
}
