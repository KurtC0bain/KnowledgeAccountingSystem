using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities;
using SystemDAL.Entities.Knowledges;

namespace SystemBLL.Interfaces
{
    public interface IKnowledgeService : IService<Knowledge>
    {
        Task AddAsync(FullKnowledge entity, string email);
        Task<IEnumerable<FullKnowledge>> GetUserKnowledge(string email);
        Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync();
        Task<FullKnowledge> GetByIdAsync(int id);
        Task UpdateAsync(FullKnowledge entity);
    }
}
