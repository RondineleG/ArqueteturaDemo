using System.ComponentModel.DataAnnotations;

namespace Proton.Register.Domain.Resources
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
        public int CategoryId { get; set; }
    }
}