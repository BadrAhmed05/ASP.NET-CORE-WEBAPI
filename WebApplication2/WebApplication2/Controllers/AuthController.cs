using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Domain.DTO;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepo tokenRepo)
        {
            this.userManager = userManager;
            this.tokenRepo = tokenRepo;
        }
        //post
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterReqDTO registerReqDTO)
        {
            var identityuser = new IdentityUser()
            {
                UserName = registerReqDTO.Username,
                Email = registerReqDTO.Username
            };
            var identityResult=await userManager.CreateAsync(identityuser, registerReqDTO.Password);
            if (identityResult.Succeeded)
            {
                //add roles to this user
                if (registerReqDTO.Roles != null && registerReqDTO.Roles.Any())
                {

                    identityResult= await userManager.AddToRolesAsync(identityuser, registerReqDTO.Roles);
                    if (identityResult.Succeeded) 
                    {
                        return Ok("User Was Registered");   
                    }
                }
            }
            return BadRequest("BaAAAAAAAAAAd");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDTO loginReqDTO )
        {
            var user = await userManager.FindByEmailAsync(loginReqDTO.Username);
            if (user != null)
            { 
              var match= await userManager.CheckPasswordAsync(user , loginReqDTO.Password);
                if (match) 
                {
                    var roles=await userManager.GetRolesAsync(user);
                    //create token
                    if (roles != null)
                    {

                        var jwt=tokenRepo.CreateJWTToken(user, roles.ToList());
                        var response=new LoginRespDTO { Jwt = jwt };

                        return Ok(response);
                    } 
                    
                }
            }
            return BadRequest("Wrongg");
                
        }


    }
}
