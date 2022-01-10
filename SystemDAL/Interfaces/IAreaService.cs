using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities;
using SystemDAL.Entities.Knowledges;

namespace SystemBLL.Interfaces
{
    public interface IAreaService : IService<Area>
    {
        IQueryable<Area> GetAllAsync();
        Task<Area> GetByIdAsync(int id);
        Task<IEnumerable<AreaRating>> GetKnowledgeAreasById(int id);
        Task<int> GetAreaIdByName(string name);
    }
}
