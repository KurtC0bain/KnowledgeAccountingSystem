using AutoMapper;
using System.Collections.Generic;

namespace SystemBLL.Profiles
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {
            CreateMap<DTO.Knowledge.FullKnowledge, SystemDAL.DTO.Knowledge.FullKnowledge>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                    dest.AreaRating,
                    opt => opt.MapFrom(src => src.AreaRating)).ReverseMap();

            CreateMap<SystemDAL.DTO.Knowledge.FullKnowledge, DTO.Knowledge.FullKnowledge>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                    dest.AreaRating,
                    opt => opt.MapFrom(src => src.AreaRating)).ReverseMap();
        }
        /*public KnowledgeProfile()
        {
            CreateMap<DTO.Knowledge.FullKnowledge, SystemDAL.DTO.Knowledge.FullKnowledge>().ReverseMap();
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest =>
                    dest.AreaRating,
                    opt => opt.MapFrom(src => src.AreaRating))
                .ReverseMap();


        }*/
    }
}
