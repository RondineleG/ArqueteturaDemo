using System.ComponentModel.DataAnnotations;

namespace Proton.Register.Domain.Resources
{
    public class SaveCityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}