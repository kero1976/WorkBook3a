using System;

namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// 正解.
    /// </summary>
    public sealed class Correct : ValueObject<Correct>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="value">正解.</param>
        public Correct(string value)
            : this(value, null)
        {
        }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="value">正解.</param>
        /// <param name="choice">回答選択肢.</param>
        public Correct(string value, Choice choice)
        {
            this.Value = value.Trim();
            this.DisplayValue = GetValue(choice);
        }

        /// <summary>
        /// 正解.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 正解の文字列.
        /// </summary>
        public string DisplayValue { get; }

        /// <inheritdoc/>
        protected override bool EqualsCore(Correct other)
        {
            return this.Value.Equals(other.Value);
        }

        private string GetValue(Choice choice)
        {
            if (choice == null || this.Value == string.Empty)
            {
                return string.Empty;
            }

            try
            {
                return choice.ChoiceList[int.Parse(this.Value) - 1].Substring(2);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
