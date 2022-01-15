using System.Threading.Tasks;

namespace SystemDAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task Delete(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}
