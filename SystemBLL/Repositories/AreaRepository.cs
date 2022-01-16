using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDAL.Context;
using SystemDAL.DTO.Knowledge;
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

        public async Task<IEnumerable<FullArea>> FindFullAreas()
        {
            List<Area> areas = await _knowledgeContext.Areas.ToListAsync();
            List<FullArea> result = new List<FullArea>();
            foreach (var area in areas)
            {
                result.Add(new FullArea
                {
                    Id = area.Id,
                    Name = area.Name,
                    AverageRating = await GetAreaAverageRating(area.Id),
                    KnowledgeWritten = _knowledgeContext.KnowledgeAreas.Where(x => x.AreaId == area.Id).Select(q => q.KnowledgeId).Count()
                });;
            }
            if (result.Count > 0) return result;
            else throw new Exception("Something wento wrog while finding areas!");
        }

        public async Task<double> GetAreaAverageRating(int id)
        {
            List<int> rating = new List<int>();
            List<KnowledgeArea> knowledge = await _knowledgeContext.KnowledgeAreas.ToListAsync();
            foreach (var item in knowledge)
            {
                if(item.AreaId == id)
                    rating.Add(item.Rating);
            }
            double av = 0.0;
            if(rating.Count > 0)
            {
                av = Math.Round(rating.Average(), 1);
            }
            return av;
        }

        public async Task<int> GetAreaIdByName(string name)
        {
            var area =  await _knowledgeContext.Areas.FirstOrDefaultAsync(x => x.Name == name);
            return area != null ? area.Id : 0;
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            return await _knowledgeContext.Areas.Include(x => x.Knowledges).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Area entity)
        {
            var element = await _knowledgeContext.Areas.FirstOrDefaultAsync(x => x.Id == entity.Id);
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
