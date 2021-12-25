﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Area entity)
        {
            await _knowledgeContext.Areas.AddAsync(entity);
            await _knowledgeContext.SaveChangesAsync();
        }

        public async Task Delete(Area entity)
        {
            var element = await _knowledgeContext.Areas.Include(x => x.Knowledges).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                _knowledgeContext.Areas.Remove(element);
            }
            await _knowledgeContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var element = await _knowledgeContext.Areas.Include(x => x.Knowledges).FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _knowledgeContext.Areas.Remove(element);
            }
            await _knowledgeContext.SaveChangesAsync();
        }

        public IQueryable<Area> FindAll()
        {
            return _knowledgeContext.Areas.Include(x => x.Knowledges);
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            return await _knowledgeContext.Areas.Include(x => x.Knowledges).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Area entity)
        {
            var element = await _knowledgeContext.Areas.Include(x => x.Knowledges).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if(element != null)
            {
                element.Knowledges = entity.Knowledges;
                element.Name = entity.Name;
            }
            _knowledgeContext.Entry(element).State = EntityState.Modified;
            await _knowledgeContext.SaveChangesAsync();
        }
    }
}
