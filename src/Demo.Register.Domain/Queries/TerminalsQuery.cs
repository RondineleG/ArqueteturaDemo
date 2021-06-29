using System;

namespace Demo.Register.Domain.Queries
{
    public class TerminalsQuery : Query
    {
        public Guid? CityId { get; set; }

        public TerminalsQuery(Guid? cityId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            CityId = cityId;
        }
    }
}