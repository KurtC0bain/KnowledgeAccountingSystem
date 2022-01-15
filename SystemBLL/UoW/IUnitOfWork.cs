using System.Threading.Tasks;
using SystemDAL.Interfaces;


namespace SystemDAL.UoW
{
    public interface IUnitOfWork
    {
        IKnowledgeRepository Knowledge { get; }
        IAreaRepository Area { get; }
        Task SaveAsync();
        int Save();
    }
}
