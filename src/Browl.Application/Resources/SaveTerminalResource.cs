using System;
using System.ComponentModel.DataAnnotations;

namespace Browl.Application.Resources
{
    public class SaveTerminalResource
    {
        [Required]
        [MaxLength(50)]
        public string NameTerminal { get; set; }

        [Required]
        public short Address { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}