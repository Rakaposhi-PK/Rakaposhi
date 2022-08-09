using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;


namespace Rakaposhi.Business.Core.Services
{
    public class UserStatusService: IService
    {
        private IRepositoryFactory _factory;
        public UserStatusService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void Add(UserStatus userStatus)
        {
            if(userStatus.RecId == null)
            {
                throw new ServiceException(ErrorCode.ADDERROR);
            }

            _factory.UserStatusRepository.Add(userStatus);
           
        }
        public void Update(UserStatus userStatus)
        {
            var found = _factory.UserStatusRepository.Find(userStatus.RecId.Value);
            if(found == null)
            {
                throw new ServiceException(ErrorCode.UPDATEERROR);
            }

            _factory.UserStatusRepository.Update(userStatus);
        }
        public void Delete(long id)
        {
            var found = _factory.UserStatusRepository.Find(id);


            _factory.UserStatusRepository.Delete(found);
        }
        public UserStatus Find(long id)
        {
            return _factory.UserStatusRepository.Find(id);
        }

        public IEnumerable<UserStatus> GetAll()
        {
           return _factory.UserStatusRepository.GetAll();
        }
    }
}
