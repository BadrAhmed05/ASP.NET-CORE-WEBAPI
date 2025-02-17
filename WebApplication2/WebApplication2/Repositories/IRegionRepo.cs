using MySqlX.XDevAPI.CRUD;
using NZWalks.API.Models.Domain;

namespace WebApplication2.Repositories
{
    public interface IRegionRepo
    {
      Task<List<Region>>GetAllASync();

        Task<Region?>GetByIdSync(string id);
        
        Task<Region>Create(Region region);
        Task<Region?>Update(string id,Region region);
        Task<Region?>Delete(string id);

    }
}
