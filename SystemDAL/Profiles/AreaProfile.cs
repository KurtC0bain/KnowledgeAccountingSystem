using AutoMapper;
using System.Linq;

namespace SystemBLL.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<DTO.Knowledge.AreaRating, SystemDAL.DTO.Knowledge.AreaRating>().ReverseMap();
            CreateMap<SystemDAL.DTO.Knowledge.AreaRating, DTO.Knowledge.AreaRating>().ReverseMap();
        }

/*        public AreaProfile()
        {
            CreateMap<DTO.Knowledge.AreaRating, SystemDAL.DTO.Knowledge.AreaRating>().ReverseMap();
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => 
                    dest.Rating,
                    opt => opt.MapFrom(src => src.Rating));


        }
*/    }
}
