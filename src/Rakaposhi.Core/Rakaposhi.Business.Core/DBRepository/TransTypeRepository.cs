using Rakaposhi.Business.Core.BaseRepository;
using Rakaposhi.Business.Core.DataObjects;
using Rakaposhi.Data;
using System.Data.Common;
using System.Text.Json;

namespace Rakaposhi.Business.Core.DBRepository
{
    public class TransTypeRepository : ITransTypeRepository
    {
        private IDatabase _db;

        public TransTypeRepository()
        {
            _db = Database.Instance;
        }

        public void Add(TransType entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.INSERT);
            _db.AddParameter(cmd, paramName: Params.NAME, paramvalue: entity.Name);
            _db.AddParameter(cmd, paramName: Params.DESCRIPTION, paramvalue: entity.Description);
            entity.RecId = Convert.ToInt64(_db.ExecuteScalar(cmd));
        }

        public void Update(TransType entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.UPDATE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.AddParameter(cmd, paramName: Params.NAME, paramvalue: entity.Name);
            _db.AddParameter(cmd, paramName: Params.DESCRIPTION, paramvalue: entity.Description);
            _db.Execute(cmd);
        }

        public void Delete(TransType entity)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.DELETE);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: entity.RecId);
            _db.Execute(cmd);
        }

        public TransType Find(long Id)
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.FIND);
            _db.AddParameter(cmd, paramName: Params.RECID, paramvalue: Id);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            TransType transactionType =  JsonSerializer.Deserialize<TransType>(found);

            return transactionType;
        }

        public IEnumerable<TransType> GetAll()
        {
            DbCommand cmd = _db.CreateStoreProcedure(storeProcedureName: StoreProcds.GETALL);
            string found = Convert.ToString(_db.ExecuteScalar(cmd));
            var transactionTypes = JsonSerializer.Deserialize<List<TransType>>(found);

            return transactionTypes;
        }

        private struct StoreProcds
        {
            public const string INSERT = "spInsertTransactionType";
            public const string UPDATE = "spUpdateTransactionType";
            public const string DELETE = "spDeleteTransactionType";
            public const string FIND = "spFindTransactionType";
            public const string GETALL = "spGetAllTransactionType";
        }

        private struct Params
        {
            public const string RECID = "RecId";
            public const string NAME = "Name";
            public const string DESCRIPTION = "Description";
        }
    }
}