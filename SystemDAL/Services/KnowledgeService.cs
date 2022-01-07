using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemBLL.Interfaces;
using SystemDAL.Entities;
using SystemDAL.Entities.Knowledges;
using SystemDAL.Interfaces;
using SystemDAL.Repositories;

namespace SystemBLL.Services
{
    /////// VALIDATION!!!

 




    public class KnowledgeService : IKnowledgeService
    {
        private IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork { get 
            { 
                if(_unitOfWork == null)
                    _unitOfWork = new UnitOfWork();
                return _unitOfWork;
            } 
        }

        public KnowledgeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Knowledge entity)
        {
            await _unitOfWork.Knowledge.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Knowledge entity)
        {
            await _unitOfWork.Knowledge.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.Knowledge.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public IQueryable<Knowledge> GetAllAsync()
        {
            return _unitOfWork.Knowledge.FindAll();
        }

        public async Task<Knowledge> GetByIdAsync(int id)
        {
            return await _unitOfWork.Knowledge.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Knowledge entity)
        {
             await _unitOfWork.Knowledge.UpdateAsync(entity);
             await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<Knowledge>> GetUserKnowledge(string id)
        {
            return await _unitOfWork.Knowledge.GetUserKnowledges(id);
        }

        public async Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync()
        {
            return await _unitOfWork.Knowledge.FindAllWithDetailsAsync();
        }
    }
}
