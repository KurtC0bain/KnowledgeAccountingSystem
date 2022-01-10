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
        Task<IEnumerable<FullKnowledge>> GetUserKnowledge(string id);
        Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync();
        Task<FullKnowledge> GetByIdAsync(int id);
        //Task<IEnumerable<Knowledge>> GetKnowledgeByArea(string areaName);
    }
}
