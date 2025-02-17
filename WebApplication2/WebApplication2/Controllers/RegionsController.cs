using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using WebApplication1.Data;
using WebApplication2.Models.Domain.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class RegionsController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public IRegionRepo RegionRepo { get; }

        public RegionsController(MyDbContext dbContext,IRegionRepo regionRepo , IMapper mapper, ILogger <RegionsController> logger)
        {
            this.dbContext = dbContext;
            RegionRepo = regionRepo;
            this.mapper = mapper;
            this.logger = logger;
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            Id=Guid.NewGuid(),
        //            Name="Auclank Region",
        //            Code="AKL",
        //            RegionImageUrl="www.google.com"
        //        },
        //        new Region
        //        {
        //            Id=Guid.NewGuid(),
        //            Name="Walli Region",
        //            Code="WGL",
        //            RegionImageUrl="www.googleto.com"
        //        }
        //    };
        //    return Ok(regions);

       // }
        [HttpGet]
       // [Authorize]

        public async Task <IActionResult> GetAllDB()
        {
            logger.LogInformation("get all action method was envoked");

            //Get Data from DATABASE - Domain Models

            // var regions = await dbContext.Regions.ToListAsync();
            var regions = await RegionRepo.GetAllASync();

            logger.LogInformation($"get all action method was finished : {JsonSerializer.Serialize(regions)}");



            //Map Domain Models to DTOs
            //var regionsDto = new List<RegionDto>();


            //foreach (var region in regions) {

            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            var regionsDto = mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDto);
        }

        //Get Single Region By ID
        [HttpGet]
        [Route("{id}")]
        public async Task <IActionResult> GetbyId([FromRoute] string id)
        { 

            // var region = dbContext.Regions.Find(id);
            var region = await RegionRepo.GetByIdSync(id); 
            if (region == null)
            {
                return NotFound();
            }

            //var regionsDto = new RegionDto
            //{
            //    Id = region.Id, 
            //    Name = region.Name,
            //    Code = region.Code,
            //    RegionImageUrl = region.RegionImageUrl
            //};

            var regionsDto=mapper.Map<RegionDto>(region);
            return Ok(regionsDto);
        }

        //POST TO  create a new region
        [HttpPost]
        public async Task <IActionResult>  create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {



            // ADD TO DATABASE

            //Map/Convert DTO TO DOmain Model
            //var regiondomainmodel = new Region
            //{
            //    Id=addRegionRequestDto.Id,
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};
            if (ModelState.IsValid)
            {



                var regiondomainmodel = mapper.Map<Region>(addRegionRequestDto);

                //await dbContext.Regions.AddAsync(regiondomainmodel);
                //await dbContext.SaveChangesAsync();
                regiondomainmodel = await RegionRepo.Create(regiondomainmodel);

                // RETRIVE FROM DATABASE

                var regionDto = mapper.Map<RegionDto>(regiondomainmodel);
                //var regionDto = new RegionDto
                //{
                //    Id = regiondomainmodel.Id,
                //    Name = regiondomainmodel.Name,
                //    Code = regiondomainmodel.Code,
                //    RegionImageUrl = regiondomainmodel.RegionImageUrl
                //};



                return CreatedAtAction(nameof(GetbyId), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //UPDATE REGION
        //PUT: https//localhiost:portno/api/regions/id
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] string id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if region exist
            // var regionDomainModel= await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //if (regionDomainModel == null)
            //{
            //    return NotFound();
            //}
            ////Map DTO to domain model
            //regionDomainModel.Code=updateRegionRequestDto.Code;
            //regionDomainModel.RegionImageUrl=updateRegionRequestDto.RegionImageUrl;
            //regionDomainModel.Name=updateRegionRequestDto.Name;
            //await dbContext.SaveChangesAsync();

            var regionDomainModel= mapper.Map<Region>(updateRegionRequestDto);

            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
               
            //};

            regionDomainModel = await RegionRepo.Update(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //retrive 
            var regionDto=mapper.Map<RegionDto>(regionDomainModel);

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};


            return Ok(regionDto);
        }


        //Delete Region
        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> delete([FromRoute] string id)
        {

            //var regionDomainModel =await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomainModel= await RegionRepo.Delete(id);
            if (regionDomainModel==null)
            {
                return NotFound();
            }
            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Name = regionDomainModel.Name,
            //    Code = regionDomainModel.Code,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};
            
            return Ok(regionDto);
            

        }

        }

    }
