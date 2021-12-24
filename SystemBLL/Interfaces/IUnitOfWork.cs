using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SystemDAL.Interfaces
{
    public interface IUnitOfWork
    {
        IKnowledgeRepository Knowledge { get; }
        IAreaRepository Area { get; }
        Task SaveAsync();
        int Save();
    }
}
