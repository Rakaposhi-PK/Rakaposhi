using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class User 
    {
        [Required]
       public long UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public long RoleID { get; set; }

        [Required]
        public long ImageID { get; set; }

    }
}
