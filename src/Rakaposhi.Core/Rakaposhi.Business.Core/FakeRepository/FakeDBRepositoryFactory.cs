using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public class FakeDBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRoleRepository;
        private IUserStatusRepository _userStatusRepository;
        private ITransRepository _transRepository;
        private IRoleRepository _roleRepository;
        private ITransTypeRepository _transTypeRepository;
        
        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if(_userRoleRepository is null)
                {
                    _userRoleRepository = new FakeUserRoleRepository();
                }

                return _userRoleRepository;
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