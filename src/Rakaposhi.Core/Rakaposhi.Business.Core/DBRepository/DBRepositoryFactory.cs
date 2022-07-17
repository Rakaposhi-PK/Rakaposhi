using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class DBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRoleRepository;

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
