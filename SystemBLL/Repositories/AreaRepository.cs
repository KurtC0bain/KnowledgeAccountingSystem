using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities.Context;
using SystemDAL.Entities.Knowledges;
using SystemDAL.Interfaces;

namespace SystemDAL.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly KnowledgeContext _knowledgeContext;
        public AreaRepository(KnowledgeContext knowladgeContext)
        {
            _knowledgeContext = knowladgeContext;
        }

        public Task AddAsync(Area entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Area entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Area> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Area> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Area entity)
        {
            throw new NotImplementedException();
        }
    }
}
