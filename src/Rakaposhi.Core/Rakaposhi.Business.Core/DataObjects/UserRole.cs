using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class UserRole : EntityBase
    {
        [Required]
        public long? UserRoleID { get; set; }

        [Required]
        public string UserRoleName { get; set; }
        
        public string UserDescription { get; set; }

        public override long Key { get => this.UserRoleID.Value; }
    }
}
