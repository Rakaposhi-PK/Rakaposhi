using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public class FakeDBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRepository;
        private IUserStatusRepository _userStatusRepository;
        private IRoleRepository _roleRepository;
        private ITransTypeRepository _transTypeRepository;

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

        public IRoleRepository RoleRepository
        {
            get
            {
                if(_roleRepository is null)
                {
                    _roleRepository = new FakeRoleRepository();
                }

                return _roleRepository;
            }
        }
        
        public ITransTypeRepository TransTypeRepository
        {
            get
            {
                if(_transTypeRepository is null)
                {
                    _transTypeRepository = new FakeTransTypeRepository();
                }

                return _transTypeRepository;
            }
        }
    }
}