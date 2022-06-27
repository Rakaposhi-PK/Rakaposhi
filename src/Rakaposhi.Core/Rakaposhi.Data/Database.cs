using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Rakaposhi.Data
{
    public class Database : IDatabase
    {
        #region Private Properties
        
        private string? _connectionString { get; set; }
        private IDatabase _instance { get; set; }

        #endregion

        #region Public Properties

        public IDatabase Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new Database();

                    return _instance;
                }

                return _instance;
            }
        }

        #endregion

        #region Constructor
        private Database()
        {

        }
        #endregion

        #region Public Methods
        public void SetConnectionString(string connectionString)
        {
            if (_connectionString is null)
            {
                _connectionString = connectionString;
            }
        }

        public DbCommand CreateStoreProcedure(string storeProcedureName)
        {
            return this.CreateStoreProcedure(storeProcedureName, CommandType.StoredProcedure); 
        }

        public void AddParameter(DbCommand cmd, string paramName, object paramvalue)
        {
            var dbParameter = cmd.CreateParameter();
            this.AddParameter(cmd, dbParameter, paramName, paramvalue); 
        }

        public void Execute(DbCommand cmd)
        {
            this.ExecuteCommand(cmd);
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            object? result = null;

            return this.ExecuteScalar(cmd, result);
        }

        #endregion

        #region Private Methods

        private DbConnection CreateConnection()
        {
            var dbConnection = new SqlConnection();
            dbConnection.ConnectionString = _connectionString;

            return dbConnection;
        }

        private DbCommand CreateStoreProcedure(string StoreProcedureName, CommandType type)
        {
            var dbCommand = new SqlCommand();
            dbCommand.CommandType = type;
            dbCommand.CommandText = StoreProcedureName;

            return dbCommand;
        }

        private void AddParameter(DbCommand cmd, DbParameter param, string paramName, object paramValue)
        {
            param.ParameterName = paramName;

            if(paramValue == null)
            {
                paramValue = DBNull.Value;
            }

            param.Value = paramValue;
            cmd.Parameters.Add(param);
        }

        private void ExecuteCommand(DbCommand cmd)
        {
            using (var con = this.CreateConnection())
            {
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private object? ExecuteScalar(DbCommand cmd, object? result)
        {
            using (var con = this.CreateConnection())
            {
                con.Open();
                cmd.Connection = con;
                result = cmd.ExecuteScalar();
                con.Close();
            }

            return result;
        }
        
        #endregion
    }
}
