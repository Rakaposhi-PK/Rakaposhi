using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class UserRole
    {
        [Required]
        public long UserRoleID { get; set; }

        [Required]
        public string Role { get; set; }

        public string UserDescription { get; set; }
    }
}
