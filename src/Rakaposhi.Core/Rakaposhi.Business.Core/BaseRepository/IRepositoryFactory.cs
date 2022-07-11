using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.BaseRepository
{
    public interface IRepositoryFactory
    {
        public IUserRepository UserRepository { get; }

        public IUserRoleRepository UserRoleRepository { get; }
    }
}
