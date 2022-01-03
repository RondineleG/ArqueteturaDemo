using System.ComponentModel.DataAnnotations;

namespace Browl.Domain.Resources
{
    public class SaveCityResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}