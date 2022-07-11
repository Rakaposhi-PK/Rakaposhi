using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;
using System.Text.Json;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private IDatabase _db;

        public UserRoleRepository()
        {
            _db = Database.Instance;
        }

        public void Add(UserRole entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.INSERT);
            _db.AddParameter(cmd, paramName: Params.USERROLENAME, entity.UserRoleName);
            _db.AddParameter(cmd, paramName: Params.USERDESCRIPTION, entity.UserDescription);
            entity.UserRoleID = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Delete(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public UserRole Find(long Id)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.FIND);
            _db.AddParameter(cmd, paramName: Params.USERROLEID, Id);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            UserRole result = JsonSerializer.Deserialize<UserRole>(found);

            return result;
        }

        public IEnumerable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserRole entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.UPDATE);
            _db.AddParameter(cmd, paramName: Params.USERROLEID, entity.UserRoleID);
            _db.AddParameter(cmd, paramName: Params.USERROLENAME, entity.UserRoleName);
            _db.AddParameter(cmd, paramName: Params.USERDESCRIPTION, entity.UserDescription);
            _db.Execute(cmd);
        }


        private struct StoreProcds
        {
            public const string INSERT = "spInsertUserRole";
            public const string UPDATE = "spUpdateUserRole";
            public const string DELETE = "spDeleteUserRole";
            public const string FIND   = "spFindUserRole";
            public const string GETALL = "spGetAllUserRole";
        }

        private struct Params
        {
            public const string USERROLEID = "UserRoleID";
            public const string USERROLENAME = "UserRoleName";
            public const string USERDESCRIPTION = "UserDescription";
        }
    }
}
