using System.Threading.Tasks;
using SystemDAL.Context;
using SystemDAL.Interfaces;
using SystemDAL.Repositories;

namespace SystemDAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private KnowledgeContext _knowledgeContext = new KnowledgeContext();

        private KnowledgeRepository _knowledgeRepository;
        private AreaRepository _areaRepository;

        public IKnowledgeRepository Knowledge
        {
            get
            {
                if (_knowledgeRepository == null)
                    _knowledgeRepository = new KnowledgeRepository(_knowledgeContext);
                return _knowledgeRepository;
            }
        }
        public IAreaRepository Area
        {
            get
            {
                if (_areaRepository == null)
                    _areaRepository = new AreaRepository(_knowledgeContext);
                return _areaRepository;
            }
        }

        public int Save()
        {
           return _knowledgeContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _knowledgeContext.SaveChangesAsync();
        }
    }
}
