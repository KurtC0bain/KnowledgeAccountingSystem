using System.Collections.Generic;
using System.Threading.Tasks;
using SystemDAL.DTO.Knowledge;
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
