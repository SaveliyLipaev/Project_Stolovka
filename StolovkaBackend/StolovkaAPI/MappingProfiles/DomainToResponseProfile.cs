using System.Linq;
using AutoMapper;
using StolovkaWebAPI.Contracts.V1.Responses;
using StolovkaWebAPI.Domain;

namespace StolovkaWebAPI.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Tags, opt => 
                    opt.MapFrom(src => src.Tags.Select(x => new TagResponse{Name = x.TagName})));
            
            CreateMap<Tag, TagResponse>();
        }
    }
}