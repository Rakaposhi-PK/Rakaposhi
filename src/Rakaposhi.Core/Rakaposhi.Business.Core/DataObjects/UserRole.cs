using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class UserRole : EntityBase
    {
        [Required]
        public long? RecId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long RoleId { get; set; }

        public override long Key { get => this.RecId.Value; }
    }
}
