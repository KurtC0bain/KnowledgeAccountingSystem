using Microsoft.EntityFrameworkCore;
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
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private KnowledgeContext _knowledgeContext;
        public KnowledgeRepository(KnowledgeContext knowladgeContext)
        {
            _knowledgeContext = knowladgeContext;
        }

        public async Task AddAsync(Knowledge entity)
        {
            await _knowledgeContext.AddAsync(entity);
            await _knowledgeContext.SaveChangesAsync();
        }

        public async Task Delete(Knowledge entity)
        {
            var element = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                _knowledgeContext.Knowledges.Remove(element);
                _knowledgeContext.SaveChanges(); 
            }
            await _knowledgeContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var element = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _knowledgeContext.Knowledges.Remove(element);
                _knowledgeContext.SaveChanges();
            }
            await _knowledgeContext.SaveChangesAsync();
        }

        public IQueryable<Knowledge> FindAll()
        {
            return _knowledgeContext.Knowledges/*.Include(x => x.Area)*/;
        }

        public async Task<Knowledge> GetByIdAsync(int id)
        {
            return await _knowledgeContext.Knowledges/*.Include(q => q.Area)*/.FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Knowledge entity)
        {
            var element = await _knowledgeContext.Knowledges.FindAsync(entity.Id);
            if(element != null)
            {
                element.Title = entity.Title;
                element.Description = entity.Description;
                element.AreaId = entity.AreaId;
                element.Rating = entity.Rating;
            }
            await _knowledgeContext.SaveChangesAsync();
        }
    }
}
