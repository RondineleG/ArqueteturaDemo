using System.ComponentModel.DataAnnotations;

namespace RegisterWS.ViewModels
{
    public class TerminalViewModel
    {

        [Key]
        [Required]
        public int IdTerminal { get; set; }

        [Required]
        public string NameTerminal { get; set; }

        public bool Status { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }


        [MaxLength(50)]
        public string District { get; set; }

        [MaxLength(50)]
        public string? CNPJ { get; set; }

        [MaxLength(50)]
        public string? NIF { get; set; }


        [MaxLength(50)]
        public string? StateRegistry { get; set; }


        [MaxLength(100)]
        public string? SpecificInstruction { get; set; }

        [MaxLength(100)]
        public string? GeneralObservation { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
