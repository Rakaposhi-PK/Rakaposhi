﻿using Rakaposhi.Business.Core.BaseRepository;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class DBRepositoryFactory : IRepositoryFactory
    {
        private IUserRoleRepository _userRoleRepository;
        private IUserStatusRepository _userStatusRepository;
        private IRoleRepository _roleRepository;

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

        public IUserStatusRepository UserStatusRepository
        {
            get
            {
                if( _userStatusRepository is null)
                {
                    _userStatusRepository = new UserStatusRepository();
                }

                return _userStatusRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if(_roleRepository is null)
                {
                    _roleRepository = new RoleRepository();
                }

                return _roleRepository;
            }
        }
    }
}
