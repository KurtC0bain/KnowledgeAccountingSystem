using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBLL.DTO.Knowledge;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Knowledges;
using SystemDAL.UoW;

namespace SystemBLL.Services
{
    public class AreaService : IAreaService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SystemDAL.DTO.Knowledge.FullArea, FullArea>().ReverseMap();
            });
            _mapper = new Mapper(config);

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

        public async Task<int> GetAreaIdByName(string name)
        {
            return await _unitOfWork.Area.GetAreaIdByName(name);
        }

        public async Task<double> GetAverageAreaRating(int id)
        {
            return await _unitOfWork.Area.GetAreaAverageRating(id);
        }

        public async Task<IEnumerable<FullArea>> FindFullAreas()
        {
            var fullAreas =  await _unitOfWork.Area.FindFullAreas();
            var result = new List<FullArea>();

            foreach (var area in fullAreas)
            {
                result.Add(_mapper.Map<SystemDAL.DTO.Knowledge.FullArea, FullArea>(area));
            }
            return result;
        }
    }
}
