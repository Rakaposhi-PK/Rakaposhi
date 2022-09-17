using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;
using System.Text.Json;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class TransRepository : ITransRepository
    {
        private IDatabase _db;

        public TransRepository()
        {
            _db = Database.Instance;
        }

        public void Add(Trans entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.INSERT);
            _db.AddParameter(cmd, paramName: Params.USERID, paramvalue: entity.UserId);
            _db.AddParameter(cmd, paramName: Params.TRANSTYPE, paramvalue: entity.Transtype);
            _db.AddParameter(cmd, paramName: Params.AMOUNT, paramvalue: entity.Amount);
            _db.AddParameter(cmd, paramName: Params.DATE, paramvalue: entity.Date);
            entity.RecId = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Update(Trans entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.UPDATE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.AddParameter(cmd, paramName: Params.USERID, paramvalue: entity.UserId);
            _db.AddParameter(cmd, paramName: Params.TRANSTYPE, paramvalue: entity.Transtype);
            _db.AddParameter(cmd, paramName: Params.AMOUNT, paramvalue: entity.Amount);
            _db.AddParameter(cmd, paramName: Params.DATE, paramvalue: entity.Date);
            _db.Execute(cmd);
        }

        public void Delete(Trans entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.DELETE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.Execute(cmd);
        }

        public Trans Find(long Id)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.FIND);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: Id);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            Trans trans = string.IsNullOrEmpty(found) ? null : 
                JsonSerializer.Deserialize<Trans>(found);

            return trans;
        }

        public IEnumerable<Trans> GetAll()
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.GETALL);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            var transactions = string.IsNullOrEmpty(found)? null :
                JsonSerializer.Deserialize<List<Trans>>(found);

            return transactions;
        }

        private struct StoreProcds
        {
            public const string INSERT = "spInsertTransaction";
            public const string UPDATE = "spUpdateTransaction";
            public const string DELETE = "spDeleteTransaction";
            public const string FIND = "spFindTransaction";
            public const string GETALL = "spGetAllTransaction";
        }

        private struct Params
        {
            public const string RECID = "RecId";
            public const string USERID = "UserId";
            public const string TRANSTYPE = "TransType";
            public const string AMOUNT = "Amount";
            public const string DATE = "Date";
        }
    }
}
