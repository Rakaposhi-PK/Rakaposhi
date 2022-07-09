using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.DBRepository
{
    internal class DBRepositoryFactory : IRepositoryFactory
    {
        private IUserRepository? _userRepository;


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
    }
}
