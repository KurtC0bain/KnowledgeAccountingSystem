using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Interfaces
{
    public interface IKnowledgeRepository : IGenericRepository<Knowledge>
    {

        Task<IEnumerable<FullKnowledge>> GetUserKnowledges(string id);
        Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync();
        Task<FullKnowledge> GetByIdAsync(int id);
    }
}
