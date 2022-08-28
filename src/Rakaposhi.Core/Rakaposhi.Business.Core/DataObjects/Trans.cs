using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class Trans : EntityBase
    {
        [Required]
        public long? RecId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long Transtype { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public override long Key { get => this.RecId.Value; }
    }
}
