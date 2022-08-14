﻿namespace Rakaposhi.Business.Core.BaseRepository
{
    public interface IRepositoryFactory
    {
        public IUserRoleRepository UserRoleRepository { get; }
        public IUserStatusRepository UserStatusRepository { get; }

        public ITransTypeRepository TransTypeRepository { get; }
    }
}
