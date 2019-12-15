using AutoMapper;
using StolovkaWebAPI.Contracts.V1.Requests.Queries;
using StolovkaWebAPI.Domain;

namespace StolovkaWebAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllPostsQuery, GetAllPostsFilter>();
        }
    }
}