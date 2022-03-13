using WorkBook3.Domain.ValueObjects;

namespace WorkBook3.Domain.Repositories
{
    /// <summary>
    /// エンティティインタフェース.
    /// </summary>
    public abstract class IEntity : ValueObject<IEntity>
    {
        /// <summary>
        /// 同じオブジェクトかを識別するための値.
        /// </summary>
        /// <returns>識別文字.</returns>
        public abstract string GetValue();

        /// <inheritdoc/>
        protected override bool EqualsCore(IEntity other)
        {
            return this.GetValue().Equals(other.GetValue());
        }
    }
}
