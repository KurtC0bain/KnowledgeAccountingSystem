using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Administration.Account.Models;
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

        public async Task AddAsync(FullKnowledge entity, string email)
        {
            List<KnowledgeArea> list = new List<KnowledgeArea>();
            var buff = await _knowledgeContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (buff != null) 
            { 
                entity.UserId = buff.Id; 
            };

            foreach (var item in entity.AreaRating)
            {
                Area area = await _knowledgeContext.Areas.FirstOrDefaultAsync(x => x.Name == item.Name);
                list.Add(new KnowledgeArea
                {
                    AreaId = area.Id,
                    Rating = item.Rating
                });
            }

            await _knowledgeContext.AddAsync(new Knowledge
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                UserId = entity.UserId,
                Areas = list
            });

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

        public async Task<IEnumerable<FullKnowledge>> GetUserKnowledges(string email)
        {
            var knowledge =  await _knowledgeContext.Knowledges.Include(a => a.User).Where(k => k.User.Email == email).ToListAsync();

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

        public async Task UpdateAsync(FullKnowledge entity)
        {
            List<KnowledgeArea> list = new List<KnowledgeArea>();
            foreach (var item in entity.AreaRating)
            {
                Area area = await _knowledgeContext.Areas.FirstOrDefaultAsync(x => x.Name == item.Name);
                list.Add(new KnowledgeArea
                {
                    AreaId = area.Id,
                    Rating = item.Rating
                });
            }
            var element = await _knowledgeContext.Knowledges.Include(x => x.Areas).FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (element != null)
            {
                element.Title = entity.Title;
                element.Description = entity.Description;
                element.UserId = entity.UserId;
                element.Areas = list;
            }
            _knowledgeContext.Entry(element).State = EntityState.Modified;

            await _knowledgeContext.SaveChangesAsync();


            

        }

    }
}
