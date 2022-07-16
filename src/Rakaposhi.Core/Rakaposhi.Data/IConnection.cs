using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Data
{
    public interface IConnection
    {
        public string? ConnectionString { get; protected set; }
        public void SetConnectionString(string dbServer, string dbName, string dbUser, string dbPassword, bool trusted);
    }
}
