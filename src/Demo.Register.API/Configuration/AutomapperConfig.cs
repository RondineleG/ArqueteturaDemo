using AutoMapper;
using Demo.Core.Extension;
using Demo.Register.Domain.Enums;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Queries;
using Demo.Register.Domain.Resources;

namespace Demo.Register.API.Configuration
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