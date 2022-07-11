using System.Data.Common;

namespace Rakaposhi.Data
{
    public interface IDatabase
    {
        void Execute(DbCommand cmd);
        void AddParameter(DbCommand cmd, string paramName, object paramvalue);
        DbCommand CreateStoreProcedure(string storeProcedureName);
        object ExecuteScalar(DbCommand cmd);
    }
}
