using Browl.Core.Base;
using Browl.Domain.Enums;
using System;

namespace Browl.Domain.Models
{

    public class Terminal : EntityBase
    {
        public Terminal()
        {
                
        }

        public string NameTerminal { get; set; }

        public EStatus Status { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string? CNPJ { get; set; }

        public string? NIF { get; private set; }

        public string? StateRegistry { get; set; }

        public string SpecificInstruction { get; set; }

        public string GeneralObservation { get; set; }

        public Guid CityId { get; set; }

        public virtual City City { get; set; }

    }
}


