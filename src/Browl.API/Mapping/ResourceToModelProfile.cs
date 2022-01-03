using AutoMapper;
using Browl.Application.Resources;
using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Queries;

namespace Browl.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCityResource, City>();

            CreateMap<SaveTerminalResource, Terminal>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => (EStatus)src.Status));

            CreateMap<ProductsQueryResource, TerminalsQuery>();
        }
    }
}