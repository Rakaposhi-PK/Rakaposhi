
using System.Reflection;

namespace Rakaposhi.Business.Core.DataObjects
{
    public abstract class EntityBase : IEntity
    {
        public abstract long Key { get; /*private protected set;*/ }

        public void Copy(IEntity entity)
        {
            var type = this.GetType();
            Copy(type, this, entity);
        }


        private void Copy(Type type, object source, object target)
        {
            var properties = type.GetProperties();

            foreach (var p in properties)
            {
                if (p.CanWrite)
                {
                    p.SetValue(source, p.GetValue(target));
                }
            }
        }
    }
}
