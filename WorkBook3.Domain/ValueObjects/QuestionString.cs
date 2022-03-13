namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// 問題文.
    /// </summary>
    public sealed class QuestionString : ValueObject<QuestionString>
    {
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="value">問題文.</param>
        public QuestionString(string value)
        {
            this.Value = value.Trim();
        }

        /// <summary>
        /// 問題文.
        /// </summary>
        public string Value { get; }

        /// <inheritdoc/>
        protected override bool EqualsCore(QuestionString other)
        {
            return this.Value.Equals(other.Value);
        }
    }
}
