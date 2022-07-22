
namespace Rakaposhi.Business.Core.DataObjects
{
    public interface IEntity
    {
        long Key { get; }
        void Copy(IEntity entity);
    }
}
