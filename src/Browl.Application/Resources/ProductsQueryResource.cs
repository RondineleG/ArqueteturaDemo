using System;

namespace Browl.Application.Resources
{
    public class ProductsQueryResource : QueryResource
    {
        public Guid? CityId { get; set; }
    }
}