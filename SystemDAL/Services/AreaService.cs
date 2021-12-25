using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Knowledges;
using SystemDAL.Interfaces;
using SystemDAL.Repositories;

namespace SystemBLL.Services
{
    public class AreaService : IAreaService
    {
        private IUnitOfWork _unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                    _unitOfWork = new UnitOfWork();
                return _unitOfWork;
            }
        }

        public AreaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Area entity)
        {
            await _unitOfWork.Area.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Area entity)
        {
            await _unitOfWork.Area.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _unitOfWork.Area.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public IQueryable<Area> GetAllAsync()
        {
            return _unitOfWork.Area.FindAll();
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            return await _unitOfWork.Area.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Area entity)
        {
            await _unitOfWork.Area.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
