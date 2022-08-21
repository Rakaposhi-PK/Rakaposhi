using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;
using System.Text.Json;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class RoleRepository : IRoleRepository
    {
        private IDatabase _db;

        public RoleRepository()
        {
            _db = Database.Instance;
        }

        public void Add(Role entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.INSERT);
            _db.AddParameter(cmd, paramName: Params.NAME, paramvalue: entity.Name);
            _db.AddParameter(cmd, paramName: Params.DESCRIPTION, paramvalue: entity.Description);
            entity.RecId = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Update(Role entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.UPDATE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.AddParameter(cmd, paramName: Params.NAME, paramvalue: entity.Name);
            _db.AddParameter(cmd, paramName: Params.DESCRIPTION, paramvalue: entity.Description);
            _db.Execute(cmd);
        }

        public void Delete(Role entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.DELETE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.Execute(cmd);
        }

        public Role Find(long Id)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.FIND);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: Id);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            Role role = string.IsNullOrEmpty(found) ? null :
                JsonSerializer.Deserialize<Role>(found);

            return role;
        }

        public IEnumerable<Role> GetAll()
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.GETALL);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            var roles = string.IsNullOrEmpty(found) ? null :
                JsonSerializer.Deserialize<List<Role>>(found);

            return roles;
        }

        private struct StoreProcds
        {
            public const string INSERT = "spInsertRole";
            public const string UPDATE = "spUpdateRole";
            public const string DELETE = "spDeleteRole";
            public const string FIND = "spFindRole";
            public const string GETALL = "spGetAllRole";
        }

        private struct Params
        {
            public const string RECID = "RecId";
            public const string NAME = "Name";
            public const string DESCRIPTION = "Description";
        }
    }
}
