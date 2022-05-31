using System.Threading.Tasks;
using SystemDAL.UoW;

namespace SystemBLL.Interfaces
{
    public interface IService<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}
