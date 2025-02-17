using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Domain;
using WebApplication2.Models.Domain.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly iImageRepo iImageRepo;

        public ImagesController(iImageRepo iImageRepo)
        {
            this.iImageRepo = iImageRepo;
        }


        //post 
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadReqDTO imageUploadReqDTO)
        {
            ValidateFileUpload(imageUploadReqDTO);
            if (ModelState.IsValid) 
            {
                var imagedomainmodel = new Image
                {
                    File = imageUploadReqDTO.File,
                    FileDesc = imageUploadReqDTO.FileDesc,
                    FileExt = Path.GetExtension(imageUploadReqDTO.File.FileName),
                    FileName = imageUploadReqDTO.File.FileName,
                    FileSize = imageUploadReqDTO.File.Length
                };

                //User Repo to upload image

                await iImageRepo.Upload(imagedomainmodel);
                return Ok(imagedomainmodel);

            }

            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadReqDTO imageUploadReqDTO)
        {
            var allowedEXT = new string[] { ".jpg", ".png",".jpeg" };
            if(allowedEXT.Contains(Path.GetExtension(imageUploadReqDTO.File.FileName))==false)
            {
                ModelState.AddModelError("file", "Unsupported file");
            }
            if (imageUploadReqDTO.File.Length > 10485760) 
            {
                ModelState.AddModelError("file", "Unsupported file length");

            }
        }
    }
}
