using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace WebApplication2.Repositories
{
    public interface IWalkRepo
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<List<Walk>> Getal( string? filterOn=null,  string? filterQuery=null,string? sortby=null,bool isAscend=true);
        Task<Walk?> GetById(int id);
        Task<Walk> Update(int id,Walk walk);
        Task <Walk>DeleteById(int id);
    }
}
