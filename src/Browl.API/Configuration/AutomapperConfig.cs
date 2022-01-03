using AutoMapper;
using Browl.Core.Extension;
using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Queries;
using Browl.Domain.Resources;

namespace Browl.API.Configuration
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