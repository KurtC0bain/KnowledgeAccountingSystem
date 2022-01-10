using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Interfaces;

namespace SystemBLL.Interfaces
{
    public interface IService<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(int id);
    }
}
