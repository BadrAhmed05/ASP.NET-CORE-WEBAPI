using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using WebApplication1.Data;
using WebApplication2.Models.Domain.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepo walkRepo;

        public WalksController(IMapper mapper, IWalkRepo walkRepo)
        {
            this.mapper = mapper;
            this.walkRepo = walkRepo;
        }
        //Create Walk
        //Post: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkReqDTO addWalkReqDTO)

        {
            try
            {
              //  throw new Exception("this was the error");
                //Map DTO to Domain Model
                var walkdomainModel = mapper.Map<Walk>(addWalkReqDTO);
                await walkRepo.CreateAsync(walkdomainModel);

                return Ok(mapper.Map<WalkDTO>(walkdomainModel));
            }
            catch (Exception ex)
            {
                //Log this exception
                return Problem("Something Went wrong" , null, (int)HttpStatusCode.InternalServerError);
                
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery]string? filterOn , [FromQuery] string? filterQuery, [FromQuery] string? sortby, [FromQuery] bool? isAscend)
        {

        
               // throw new Exception("this was the error");

                var walkdomainModel = await walkRepo.Getal(filterOn, filterQuery, sortby, isAscend ?? true);

                throw new Exception("this is an exception");

                return Ok(mapper.Map<List<WalkDTO>>(walkdomainModel));

        }
        [HttpGet]
        //lazm t3ml l route 

        //get by id
        [Route("{id}")]
        public async Task<IActionResult>GetById([FromRoute] int id)
        {
            var walkdomainModel= await walkRepo.GetById(id);
            if (walkdomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkdomainModel));   
        }
        [HttpPut]
        //lazm t3ml l route 

        //get by id
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id , UpdateDTO updateDTO)
        {
            var walkdomainModel=mapper.Map<Walk>(updateDTO);
            walkdomainModel= await walkRepo.Update(id,walkdomainModel);
            if (walkdomainModel == null)
            { return NotFound(); }

            return Ok(mapper.Map<WalkDTO>(walkdomainModel));
                
            }

        [HttpDelete]
        [Route("{id}")]

        public async Task <IActionResult>Delete(int id)
        {
            var deletewait=await walkRepo.DeleteById(id);
            if(deletewait == null)
                { return NotFound(); }  
            return Ok(mapper.Map<WalkDTO>(deletewait));
        }
    }
}
