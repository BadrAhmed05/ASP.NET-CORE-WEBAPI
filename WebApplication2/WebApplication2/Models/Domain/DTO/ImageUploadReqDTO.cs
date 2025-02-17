using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Domain.DTO
{
    public class ImageUploadReqDTO
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }

        public string? FileDesc { get; set; }
    }
}
