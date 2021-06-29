using System;

namespace Proton.Register.Application.Resources
{
    public class ProductsQueryResource : QueryResource
    {
        public Guid? CityId { get; set; }
    }
}