using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class DBRepositoryFactory : IRepositoryFactory
    {
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if(_userRepository is null)
                {
                    _userRepository = new UserRepository();
                }

                return _userRepository;
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if(_userRoleRepository is null)
                {
                    _userRoleRepository = new UserRoleRepository();
                }

                return _userRoleRepository;
            }
        }
    }
}
