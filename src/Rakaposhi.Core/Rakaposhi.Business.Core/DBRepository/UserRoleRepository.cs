using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;

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
            _db.AddParameter(cmd, paramName: Params.USERROLE, entity.Role);
            _db.AddParameter(cmd, paramName: Params.USERDESCRIPTION, entity.UserDescription);
            entity.UserRoleID = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Delete(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public UserRole Find(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserRole entity)
        {
            throw new NotImplementedException();
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
            public const string USERROLE = "UserRole";
            public const string USERDESCRIPTION = "UserDescription";
        }
    }
}
