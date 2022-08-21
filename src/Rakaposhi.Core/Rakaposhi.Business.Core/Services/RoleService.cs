using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;

namespace Rakaposhi.Business.Core.Services
{
    public class RoleService : IService
    {
        private IRepositoryFactory _factory;

        public RoleService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void Add(Role roles)
        {
            if (roles.RecId == null)
            {
                throw new ServiceException(ErrorCode.ADDERROR);
            }

            _factory.RoleRepository.Add(roles);
        }

        public void Update(Role roles)
        {
            var found = _factory.RoleRepository.Find(roles.RecId.Value);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.UPDATEERROR);
            }

            _factory.RoleRepository.Update(roles);
        }

        public void Delete(long id)
        {
            var found = _factory.RoleRepository.Find(id);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.DELETEERROR);
            }

            _factory.RoleRepository.Delete(found);
        }

        public Role Find(long id)
        {
            return _factory.RoleRepository.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _factory.RoleRepository.GetAll();
        }
    }
}
