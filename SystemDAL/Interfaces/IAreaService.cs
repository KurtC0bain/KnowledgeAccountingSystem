using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities.Knowledges;

namespace SystemBLL.Interfaces
{
    public interface IAreaService : IService<Area>
    {
        Task<IEnumerable<Area>> GetKnowledgeAreasById(int id);
    }
}
