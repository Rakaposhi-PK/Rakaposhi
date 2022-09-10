using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;

namespace Rakaposhi.Business.Core.Services
{
    public class UserRoleService : IService
    {
        private IRepositoryFactory _factory;

        public UserRoleService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void Add(UserRole userRole)
        {
            if(userRole.RecId == null)
            {
                throw new ServiceException(ErrorCode.ADDERROR);
            }

            _factory.UserRoleRepository.Add(userRole);
        }

        public void Update(UserRole userRole)
        {
            var found = _factory.UserRoleRepository.Find(userRole.RecId.Value);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.UPDATEERROR);
            }

            _factory.UserRoleRepository.Update(userRole);
        }

        public void Delete(long Id)
        {
            var found = _factory.UserRoleRepository.Find(Id);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.DELETEERROR);
            }

            _factory.UserRoleRepository.Delete(found);
        }

        public UserRole Find(long Id)
        {
            return _factory.UserRoleRepository.Find(Id);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _factory.UserRoleRepository.GetAll();
        }
    }
}