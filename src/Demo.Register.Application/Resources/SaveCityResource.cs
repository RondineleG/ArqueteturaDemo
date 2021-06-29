using System.ComponentModel.DataAnnotations;

namespace Proton.Register.Application.Resources
{
    public class SaveCityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}