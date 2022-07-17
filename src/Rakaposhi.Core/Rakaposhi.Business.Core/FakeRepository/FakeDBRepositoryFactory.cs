using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public class FakeDBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRepository;

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if(_userRepository is null)
                {
                    _userRepository = new FakeUserRoleRepository();
                }

                return _userRepository;
            }
        }
    }
}
