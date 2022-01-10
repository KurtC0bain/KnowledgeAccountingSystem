using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities;
using SystemDAL.Entities.Context;
using SystemDAL.Entities.Knowledges;
using SystemDAL.Interfaces;
using Z.EntityFramework.Plus;

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
            await _knowledgeContext.Knowledges.AddAsync(entity);
            await _knowledgeContext.SaveChangesAsync();
        }
        public async Task Delete(Knowledge entity)
        {
            var element = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                _knowledgeContext.Knowledges.Remove(element);
            }
            await _knowledgeContext.SaveChangesAsync();

        }
        public async Task DeleteByIdAsync(int id)
        {
            var element = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _knowledgeContext.Knowledges.Remove(element);
            }
            await _knowledgeContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Knowledge entity)
        {
            var element = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                element.Description = entity.Description;
                element.Title = entity.Title;
                element.Areas = null;
                element.Areas = entity.Areas;
            }
            _knowledgeContext.Entry(element).State = EntityState.Modified;
            await _knowledgeContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync()
        {
            var knowledges = await _knowledgeContext.Knowledges.ToListAsync();
            var result = new List<FullKnowledge>();
            foreach(var item in knowledges)
            {
                result.Add(new FullKnowledge
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    UserId = item.UserId,
                    AreaRating = await GetKnowledgeAreasById(item.Id)
                });
            }
            return result;
        }
        public async Task<FullKnowledge> GetByIdAsync(int id)
        {
            var knowledge = await _knowledgeContext.Knowledges.FirstOrDefaultAsync(x => x.Id == id);
            return new FullKnowledge
            {
                Id = knowledge.Id,
                Title = knowledge.Title,
                Description = knowledge.Description,
                UserId = knowledge.UserId,
                AreaRating = await GetKnowledgeAreasById(id)
            };

        }

        public async Task<IEnumerable<FullKnowledge>> GetUserKnowledges(string id)
        {
            var knowledge =  await _knowledgeContext.Knowledges.Include(a => a.Areas).Where(k => k.UserId == id).ToListAsync();
            var result = new List<FullKnowledge>();
            foreach (var item in knowledge)
            {
                result.Add(new FullKnowledge
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    UserId = item.UserId,
                    AreaRating = await GetKnowledgeAreasById(item.Id)
                });
            }
            return result;
        }


        public async Task<IEnumerable<AreaRating>> GetKnowledgeAreasById(int id)
        {
            List<Area> areas = await _knowledgeContext.Areas.ToListAsync();
            List<KnowledgeArea> knowledgeAreas = await _knowledgeContext.KnowledgeAreas.ToListAsync();

            return areas.Join(knowledgeAreas.Where(x => x.KnowledgeId == id),
                 area => area,
                 knowAr => knowAr.Area,
                 (area, rating) => new AreaRating
                 {
                     Id = area.Id,
                     Name = area.Name,
                     Rating = rating.Rating
                 });
        }


    }
}
