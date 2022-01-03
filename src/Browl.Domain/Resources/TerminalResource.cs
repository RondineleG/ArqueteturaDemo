using System;

namespace Browl.Domain.Resources
{
    public class TerminalResource
    {
        public Guid TerminalId { get; set; }
        public string NameTerminal { get; set; }
        public int Address { get; set; }
        public string Status { get; set; }
        public CityResource City { get; set; }
    }
}