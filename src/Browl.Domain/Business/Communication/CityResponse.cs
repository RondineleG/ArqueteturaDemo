using Browl.Domain.Models;

namespace Browl.Domain.Business.Communication
{
    public class CityResponse : BaseResponse<City>
    {
        public CityResponse(City city) : base(city) { }

        public CityResponse(string message) : base(message) { }
    }
}