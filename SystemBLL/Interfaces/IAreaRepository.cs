using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        Task AddAsync(Area entity);
        IQueryable<Area> FindAll();
        Task UpdateAsync(Area entity);

        Task<Area> GetByIdAsync(int id);
        Task<IEnumerable<AreaRating>> GetKnowledgeAreasById(int id);
        Task<int> GetAreaIdByName(string name);
        Task<double> GetAreaAverageRating(int id);
        Task<IEnumerable<FullArea>> FindFullAreas();
    }
}
