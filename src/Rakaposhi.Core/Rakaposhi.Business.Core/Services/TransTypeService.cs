using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;

namespace Rakaposhi.Business.Core.Services
{
    public class TransTypeService : IService
    {
        private IRepositoryFactory _factory;

        public TransTypeService(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public void Add(TransType transType)
        {
            if (transType.RecId == null)
            {
                throw new ServiceException(ErrorCode.ADDERROR);
            }

            _factory.TransTypeRepository.Add(transType);
        }

        public void Update(TransType transType)
        {
            var found = _factory.TransTypeRepository.Find(transType.RecId.Value);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.UPDATEERROR);
            }

            _factory.TransTypeRepository.Update(transType);
        }

        public void Delete(long Id)
        {
            var found = _factory.TransTypeRepository.Find(Id);

            if (found == null)
            {
                throw new ServiceException(ErrorCode.DELETEERROR);
            }

            _factory.TransTypeRepository.Delete(found);
        }

        public TransType Find(long Id)
        {
            return _factory.TransTypeRepository.Find(Id);
        }

        public IEnumerable<TransType> GetAll()
        {
            return _factory.TransTypeRepository.GetAll();
        }
    }
}
