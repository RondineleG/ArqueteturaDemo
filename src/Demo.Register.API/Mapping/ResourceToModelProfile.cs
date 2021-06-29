using AutoMapper;
using Proton.Register.Application.Resources;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;

namespace Proton.Register.API.Mapping
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