using Rakaposhi.Business.Core.Helper;
using System.ComponentModel.DataAnnotations;

namespace Rakaposhi.Business.Core.DataObjects
{
    public class UserRole : IEntity
    {
        [Required]
        public long? UserRoleID { get; set; }

        [Required]
        public string UserRoleName { get; set; }

        public string UserDescription { get; set; }

        public long Key => UserRoleID.Value;
            
        public void Copy(IEntity entity)
        {
            CopyObjectHelper.Copy<UserRole>(this, entity);
        }
    }
}
