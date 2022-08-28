using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public class FakeDBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRepository;
        private IUserStatusRepository _userStatusRepository;
        private ITransRepository _transRepository;

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

        public ITransRepository TransRepository
        {
            get
            {
                if(_transRepository is null)
                {
                    _transRepository = new FakeTransRepository();
                }

                return _transRepository;
            }
        }
    }
}
