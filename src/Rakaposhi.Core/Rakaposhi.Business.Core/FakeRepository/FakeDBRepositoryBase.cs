using Rakaposhi.Business.Core.DataObjects;

namespace Rakaposhi.Business.Core.FakeRepository
{
    public abstract class FakeDBRepositoryBase<T> where T : IEntity
    {
        private List<T> _list;

        public FakeDBRepositoryBase()
        {
            _list = new List<T>();
        }


        public void Add(T entity)
        {
            _list.Add(entity);
        }

        public void Delete(T entity)
        {
            _list.Remove(entity);
        }

        public T Find(long id)
        {
            return _list.Find(x => x.Key == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public void Update(T entity)
        {
            T found = Find(entity.Key);
            found.Copy(entity);
        }
    }
}
