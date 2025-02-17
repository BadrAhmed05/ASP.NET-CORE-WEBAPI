using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Repositories
{
    public interface ITokenRepo
    {
       string CreateJWTToken(IdentityUser user,List<string> roles);
    }
}
