using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models.Domain
{
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public string FileName { get; set; }

        public string? FileDesc { get; set; }

        public string FileExt { get; set; }

        public long FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
