using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {



        Task Delete(TEntity entity);

        Task DeleteByIdAsync(int id);
    }
}
