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
        Task AddAsync(FullKnowledge entity, string email);
        Task<IEnumerable<FullKnowledge>> GetUserKnowledges(string email);
        Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync();
        Task<FullKnowledge> GetByIdAsync(int id);
        Task UpdateAsync(FullKnowledge entity);
    }
}
