using System;

namespace Demo.Register.Application.Resources
{
    public class ProductsQueryResource : QueryResource
    {
        public Guid? CityId { get; set; }
    }
}