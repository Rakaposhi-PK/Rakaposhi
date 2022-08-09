using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public class FakeDBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRepository;
        private IUserStatusRepository _userStatusRepository;

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

        public IUserStatusRepository UserStatusRepository
        {
            get
            {
                if(_userStatusRepository is null)
                {
                    _userStatusRepository = new FakeUserStatusRepository();
                }

                return _userStatusRepository;
            }
        }
    }
}
