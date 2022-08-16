using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class TransType : EntityBase
    {
        [Required]
        public long? RecId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public override long Key { get => this.RecId.Value; }
    }
}
