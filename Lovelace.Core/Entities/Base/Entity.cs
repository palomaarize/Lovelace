using System.Diagnostics.CodeAnalysis;

namespace Lovelace.Core.Entities.Base.Entity
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntity
    {
        public long Id { get; set; }
    }
}
