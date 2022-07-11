using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Rakaposhi.Data
{
    public class Database : IDatabase
    {
        #region Private Properties

        private string? _connectionString;
        private static IDatabase? _instance;

        #endregion

        #region Public Properties

        public static IDatabase Instance
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

        public static Database FullInstance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new Database();
                }

                return (Database)_instance;
            }
        }

        #endregion

        #region Constructor
        private Database()
        {

        }
        #endregion

        #region Public Methods
        public void SetConnectionString(string dbServer, string dbName, string dbUser, string dbPassword, bool trusted)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();


            builder.DataSource = dbServer;
            builder.InitialCatalog = dbName;
            builder.IntegratedSecurity = trusted;

            if (!trusted)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = dbUser;
                builder.Password = dbPassword;
            }

            this._connectionString = builder.ConnectionString;
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

            this.ExecuteScalar(cmd, out result);

            return result is null ? string.Empty : result;
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

        private void ExecuteScalar(DbCommand cmd, out object? result)
        {
            using (var con = this.CreateConnection())
            {
                con.Open();
                cmd.Connection = con;
                result = cmd.ExecuteScalar();
                con.Close();
            }
        }
        
        #endregion
    }
}
