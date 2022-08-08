using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class UserStatus : EntityBase
    {
        [Required]
        public long? RecId { get; set; }

        [Required]
        public string Status { get; set; }

        public override long Key  { get => this.RecId.Value; }
    }
}
