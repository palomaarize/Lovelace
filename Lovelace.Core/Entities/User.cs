using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Lovelace.Core.Entities.Base.Entity
{
    [ExcludeFromCodeCoverage]
    [Table("user")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}