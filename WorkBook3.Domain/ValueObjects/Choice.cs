using System.Collections.Generic;
using WorkBook3.Domain.Exceptions;

namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// 回答選択肢.
    /// </summary>
    public sealed class Choice : ValueObject<Choice>
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="value">回答選択肢.</param>
        public Choice(string value)
        {
            _logger.Debug("コンストラクタ:{0}", value);
            this.Value = value.Trim();
        }

        /// <summary>
        /// 回答選択肢.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 画面表示用.
        /// </summary>
        public string DisplayValue => string.Join("\n", this.ChoiceList);

        /// <summary>
        /// 1つのstringを4つの問題に分解.
        /// </summary>
        /// <returns>回答選択肢.</returns>
        public List<string> ChoiceList
        {
            get
            {
                List<string> result = new List<string>();
                string temp = this.Value;

                int index;
                for (int i = 1; i <= 4; i++)
                {
                    index = temp.IndexOf(i + ".");
                    if (index == -1)
                    {
                        _logger.Debug("エラー：{0}問目が見つかりませんでした", i);
                        throw new DataParseException(i + "問目が見つかりませんでした。");
                    }

                    if (i != 1)
                    {
                        // 最初のループはデータを詰めない
                        result.Add(temp.Substring(0, index).Trim().Replace("\n", " "));
                    }

                    temp = temp.Substring(index);
                }

                // 最後は残りを全部入れる
                result.Add(temp.Trim().Replace("\n", " "));
                _logger.Debug(string.Join(", ", result));
                return result;
            }
        }

        /// <inheritdoc/>
        protected override bool EqualsCore(Choice other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}
