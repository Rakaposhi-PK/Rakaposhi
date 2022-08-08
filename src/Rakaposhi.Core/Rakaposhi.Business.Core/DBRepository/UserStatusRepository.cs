using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;

namespace Rakaposhi.Business.Core.DBRepository
{
    internal class UserStatusRepository : IUserStatusRepository
    {
        private IDatabase _db;

        public UserStatusRepository()
        {
            _db = Database.Instance;
        }

        public void Add(UserStatus entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.INSERT);
            _db.AddParameter(cmd, paramName: Params.STATUS, paramvalue: entity.Status);
            entity.RecId = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Delete(UserStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserStatus entity)
        {
            throw new NotImplementedException();
        }

        UserStatus IGenericRepository<UserStatus>.Find(long Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserStatus> IGenericRepository<UserStatus>.GetAll()
        {
            throw new NotImplementedException();
        }

        private struct StoreProcds
        {
            public const string INSERT = "spInsertUserStatus";
            public const string UPDATE = "spUpdateUserStatus";
            public const string DELETE = "spDeleteUserStatus";
            public const string FIND = "spFindUserStatus";
            public const string GETALL = "spGetAllUserStatus";
        }

        private struct Params
        {
            public const string RECID = "RecId";
            public const string STATUS = "Status";
        }
    }
}
