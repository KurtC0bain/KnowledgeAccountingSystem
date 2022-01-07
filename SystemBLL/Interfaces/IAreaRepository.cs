using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        Task<IEnumerable<Area>> GetKnowledgeAreasById(int id);
    }
}
