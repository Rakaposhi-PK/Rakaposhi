using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class Role : EntityBase
    {
        [Required]
        public long? RecId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public override long Key { get => RecId.Value; }
    }
}
