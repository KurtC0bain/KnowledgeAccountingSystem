using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemBLL.DTO.Knowledge;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Knowledges;
using SystemDAL.UoW;

namespace SystemBLL.Services
{
    /////// VALIDATION!!!
    
    public class KnowledgeService : IKnowledgeService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<SystemDAL.DTO.Knowledge.FullKnowledge, FullKnowledge>().ReverseMap();
                c.CreateMap<SystemDAL.DTO.Knowledge.AreaRating, AreaRating>().ReverseMap();
                });
            _mapper = new Mapper(config);
        }

        public async Task AddAsync(FullKnowledge entity, string email)
        {
            //MAPPER
            var fullKnowledge = _mapper.Map<FullKnowledge, SystemDAL.DTO.Knowledge.FullKnowledge>(entity);

            await _unitOfWork.Knowledge.AddAsync(fullKnowledge, email);
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

        public async Task<FullKnowledge> GetByIdAsync(int id)
        {
            var fullKnowledge =  await _unitOfWork.Knowledge.GetByIdAsync(id);
            return _mapper.Map<SystemDAL.DTO.Knowledge.FullKnowledge, FullKnowledge>(fullKnowledge);
        }
        public async Task<IEnumerable<FullKnowledge>> GetUserKnowledge(string email)
        {
            var userKnowledge = await _unitOfWork.Knowledge.GetUserKnowledges(email);
            List<FullKnowledge> result = new List<FullKnowledge>();
            foreach (var item in userKnowledge)
            {
                result.Add(_mapper.Map<SystemDAL.DTO.Knowledge.FullKnowledge, FullKnowledge>(item));
            }
            return result;

        }
        public async Task<IEnumerable<FullKnowledge>> FindAllWithDetailsAsync()
        {
            var findAll = await _unitOfWork.Knowledge.FindAllWithDetailsAsync();

            List<FullKnowledge> result = new List<FullKnowledge>();

            foreach (var item in findAll)
            {
                result.Add(_mapper.Map<SystemDAL.DTO.Knowledge.FullKnowledge, FullKnowledge>(item));
            }
            return result;
        }

        public async Task UpdateAsync(FullKnowledge entity)
        {
            var fullKnowledge = _mapper.Map<FullKnowledge,SystemDAL.DTO.Knowledge.FullKnowledge>(entity);
            await _unitOfWork.Knowledge.UpdateAsync(fullKnowledge);
        }
    }
}
