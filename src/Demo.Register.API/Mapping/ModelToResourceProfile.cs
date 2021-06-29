using AutoMapper;
using Demo.Register.API.Extensions;
using Demo.Register.Application.Resources;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Queries;

namespace Demo.Register.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<City, CityResource>();

            CreateMap<Terminal, TerminalResource>()
                .ForMember(src => src.Status,
                           opt => opt.MapFrom(src => src.Status.ToDescriptionString()));

            CreateMap<QueryResult<Terminal>, QueryResultResource<TerminalResource>>();
        }
    }
}