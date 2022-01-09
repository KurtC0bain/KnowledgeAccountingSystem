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
        Task<IEnumerable<Knowledge>> GetUserKnowledge(string id);
        Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync();
        Task<IEnumerable<Knowledge>> GetKnowledgeByArea(string areaName);
    }
}
