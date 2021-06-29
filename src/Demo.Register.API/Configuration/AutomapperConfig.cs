using AutoMapper;
using Proton.Core.Extension;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;
using Proton.Register.Domain.Resources;

namespace Proton.Register.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

            CreateMap<SaveTerminalResource, Terminal>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => (EStatus)src.Status));


            CreateMap<Terminal, TerminalResource>()
                 .ForMember(src => src.Status,
                            opt => opt.MapFrom(src => src.Status.ToDescriptionString()));

            CreateMap<QueryResult<Terminal>, QueryResultResource<TerminalResource>>();

            CreateMap<ProductsQueryResource, TerminalsQuery>().ReverseMap();


            CreateMap<City, CityResource>();

            CreateMap<Terminal, TerminalResource>()
                .ForMember(src => src.Status,
                           opt => opt.MapFrom(src => src.Status.ToDescriptionString()));


            CreateMap<SaveCityResource, City>();

            CreateMap<SaveTerminalResource, Terminal>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => (EStatus)src.Status));

            CreateMap<QueryResult<Terminal>, QueryResultResource<TerminalResource>>();


        }
    }
}