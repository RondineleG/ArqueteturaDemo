using System;

namespace Proton.Register.Domain.Core.Queries
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