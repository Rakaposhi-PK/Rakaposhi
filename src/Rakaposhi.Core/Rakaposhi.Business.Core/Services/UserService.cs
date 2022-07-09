using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;

namespace Rakaposhi.Business.Core.Services
{
    public class UserService : IService
    {
        IRepositoryFactory _factory;

        public UserService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void Add(User user)
        {
            _factory.UserRepository.Add(user);
        }

        public void Update(User user)
        {
            var found = _factory.UserRepository.Find(user.UserID);

            if(found == null)
            {
                //Raise Exception
            }

            _factory.UserRepository.Update(user);
        }

        public void Delete(long Id)
        {
            var found = _factory.UserRepository.Find(Id);

            if(found == null)
            {
                //Raise Exception
            }

            _factory.UserRepository.Delete(found);
        }

        public User Find(long Id)
        {

            return _factory.UserRepository.Find(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _factory.UserRepository.GetAll();
        }

    }
}
