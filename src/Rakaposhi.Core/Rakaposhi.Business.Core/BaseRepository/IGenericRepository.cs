using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakaposhi.Business.Core.BaseRepository
{
    internal interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Find(long Id);

        IEnumerable<T> GetAll();

    }
}
