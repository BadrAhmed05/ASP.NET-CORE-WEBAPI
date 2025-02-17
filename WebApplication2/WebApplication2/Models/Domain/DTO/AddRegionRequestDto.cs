using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Domain.DTO
{
    public class AddRegionRequestDto
    {

        public string Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="TLATA BAS YAAD")]
        [MaxLength(3,ErrorMessage = "TLATA BAS YGHBAAAyy")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
