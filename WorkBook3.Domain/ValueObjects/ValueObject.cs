namespace WorkBook3.Domain.ValueObjects
{
    /// <summary>
    /// バリューオブジェクトベースクラス.
    /// </summary>
    /// <typeparam name="T">バリューオブジェクトのクラス.</typeparam>
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        /// <summary>
        /// ==比較.
        /// </summary>
        /// <param name="vo1">比較対象1.</param>
        /// <param name="vo2">比較対象2.</param>
        /// <returns>比較結果.</returns>
        public static bool operator ==(
    ValueObject<T> vo1,
    ValueObject<T> vo2) => Equals(vo1, vo2);

        /// <summary>
        /// !=比較.
        /// </summary>
        /// <param name="vo1">比較対象1.</param>
        /// <param name="vo2">比較対象2.</param>
        /// <returns>比較結果.</returns>
        public static bool operator !=(
    ValueObject<T> vo1,
    ValueObject<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (vo == null)
            {
                return false;
            }

            return this.EqualsCore(vo);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Equalsの実装.
        /// </summary>
        /// <param name="other">比較するオブジェクト.</param>
        /// <returns>結果.</returns>
        protected abstract bool EqualsCore(T other);
    }
}
