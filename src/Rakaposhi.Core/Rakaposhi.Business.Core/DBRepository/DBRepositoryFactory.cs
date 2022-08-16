using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class DBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRoleRepository;
        private IUserStatusRepository _userStatusRepository;
        private ITransTypeRepository _transTypeRepository;

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository is null)
                {
                    _userRoleRepository = new UserRoleRepository();
                }

                return _userRoleRepository;
            }
        }

        public IUserStatusRepository UserStatusRepository
        {
            get
            {
                if (_userStatusRepository is null)
                {
                    _userStatusRepository = new UserStatusRepository();
                }

                return _userStatusRepository;
            }
        }

        public ITransTypeRepository TransTypeRepository
        {
            get
            {
                if (_transTypeRepository is null)
                {
                    _transTypeRepository = new TransTypeRepository();
                }

                return _transTypeRepository;
            }
        }
    }
}
