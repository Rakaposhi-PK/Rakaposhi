//using Rakaposhi.Business.Core.BaseRepository;
//using Rakaposhi.Business.Core.DataObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Rakaposhi.Business.Core.Services
//{
//    public class TransService : IService
//    {
//        private IRepositoryFactory _factory;

//        public TransService(IRepositoryFactory factory)
//        {
//            _factory = factory;
//        }

//        public void Add(Trans trans)
//        {
//            if (trans.RecId == null || trans.UserId == null || trans.Transtype == null)
//            {
//                throw new ServiceException(ErrorCode.ADDERROR);
//            }

//            _factory.TransRepository.Add(trans);

//        }
//        public void Update(Trans trans)
//        {
//            var found = _factory.TransRepository.Find(trans.RecId.Value);
            
//            if (found == null)
//            {
//                throw new ServiceException(ErrorCode.UPDATEERROR);
//            }

//            _factory.TransRepository.Update(trans);
//        }
//        public void Delete(long id)
//        {
//            var found = _factory.TransRepository.Find(id);


//            _factory.TransRepository.Delete(found);
//        }
//        public Trans Find(long id)
//        {
//            return _factory.TransRepository.Find(id);
//        }

//        public IEnumerable<Trans> GetAll()
//        {
//            return _factory.TransRepository.GetAll();
//        }
//    }
//}
