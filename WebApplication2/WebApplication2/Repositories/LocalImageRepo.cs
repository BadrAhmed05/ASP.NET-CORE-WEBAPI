using WebApplication2.Data;
using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public class LocalImageRepo : iImageRepo
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksAuthDBContext nZWalksAuthDBContext;

        public LocalImageRepo(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor , NZWalksAuthDBContext nZWalksAuthDBContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.nZWalksAuthDBContext = nZWalksAuthDBContext;
        }


        public async Task<Image> Upload(Image image)
        {
             var localpath = Path.Combine(webHostEnvironment.ContentRootPath,"Images",$"{image.FileName}{image.FileExt}");
            //upload image to local path
            using var stream = new FileStream(localpath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https//localhost:1234/images/image.jpg

            var urlfilepath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExt}";

            image.FilePath = urlfilepath;

            //add image to images table

            await nZWalksAuthDBContext.Images.AddAsync(image);
            await nZWalksAuthDBContext.SaveChangesAsync();
            return image;





        }
    }
}
