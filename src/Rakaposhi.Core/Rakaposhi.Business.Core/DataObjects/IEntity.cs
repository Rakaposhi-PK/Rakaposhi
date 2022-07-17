using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.DataObjects
{
    public interface IEntity
    {
        long Key { get; }
        void Copy(IEntity entity);
    }
}
