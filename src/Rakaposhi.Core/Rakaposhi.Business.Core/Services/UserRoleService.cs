﻿using Rakaposhi.Business.Core.BaseRepository;
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
            _factory.UserRoleRepository.Add(userRole);
        }

        public void Update(UserRole userRole)
        {
            var found = _factory.UserRoleRepository.Find(userRole.UserRoleID);

            if (found == null)
            {
                //Raise Exception
            }

            _factory.UserRoleRepository.Update(userRole);
        }

        public void Delete(long Id)
        {
            var found = _factory.UserRoleRepository.Find(Id);

            if (found == null)
            {
                //Raise Exception
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
