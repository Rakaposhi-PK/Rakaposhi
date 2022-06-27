using System.Data.Common;

namespace Rakaposhi.Data
{
    public interface IDatabase
    {
        void Execute(DbCommand cmd);
        DbCommand CreateStoreProcedure(string storeProcedureName);
        object ExecuteScalar(DbCommand cmd);
    }
}
