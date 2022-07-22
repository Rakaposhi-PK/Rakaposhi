using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.Services
{
    public class ErrorCode
    {
        public const string ADDERROR = "ID can't be null, Please Insert ID";
        public const string UPDATEERROR = "Unable to update record, Record doesn't exist.";
        public const string DELETEERROR = "Unable to delete record, Record doesn't exist.";
    }
}
