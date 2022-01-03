using AutoMapper;
using Browl.API.Extensions;
using Browl.Application.Resources;
using Browl.Domain.Models;
using Browl.Domain.Queries;

namespace Browl.API.Mapping
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