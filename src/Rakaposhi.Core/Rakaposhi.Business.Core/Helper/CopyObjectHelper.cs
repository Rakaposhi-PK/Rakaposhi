using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.Helper
{
    public static class CopyObjectHelper
    {
        public static void Copy<T>(object source, object target)
        {
            Copy(typeof(T), source, target);
        }

        private static void Copy(Type type, object source, object target)
        {
            var properties = type.GetProperties();

            foreach(var p in properties)
            {
                p.SetValue(target, p.GetValue(source));
            }
        }
    }
}
