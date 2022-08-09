using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;
using System.Text.Json;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class UserStatusRepository : IUserStatusRepository
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
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.DELETE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.Execute(cmd);
        }

        public void Update(UserStatus entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.UPDATE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.AddParameter(cmd, paramName: Params.STATUS, paramvalue: entity.Status);
            _db.Execute(cmd);
        }

        public UserStatus Find(long Id)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.FIND);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: Id);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            UserStatus userStatus = JsonSerializer.Deserialize<UserStatus>(found);

            return userStatus;
        }

        public IEnumerable<UserStatus> GetAll()
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.GETALL);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            var userStatuses = JsonSerializer.Deserialize<List<UserStatus>>(found);
            
            return userStatuses;
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
