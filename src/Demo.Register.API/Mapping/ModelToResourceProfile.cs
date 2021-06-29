using AutoMapper;
using Proton.Register.API.Extensions;
using Proton.Register.Application.Resources;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;

namespace Proton.Register.API.Mapping
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