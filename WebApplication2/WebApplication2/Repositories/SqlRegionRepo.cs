using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using WebApplication1.Data;
using WebApplication2.Models.Domain.DTO;

namespace WebApplication2.Repositories
{
    public class SqlRegionRepo : IRegionRepo
    {
        private readonly MyDbContext myDbContext;

        public SqlRegionRepo(MyDbContext myDbContext) {
            this.myDbContext = myDbContext;
        }

        public async Task<Region> Create(Region region)
        {
            await myDbContext.Regions.AddAsync(region);
            await myDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> Delete(string id)
        {
            var regionDomainModel = await myDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null)
            {
                return null;
            }
            myDbContext.Regions.Remove(regionDomainModel);
            await myDbContext.SaveChangesAsync();
            return regionDomainModel;
        }

        public async Task<List<Region>> GetAllASync()
        {
          return await myDbContext.Regions.ToListAsync();
        }

        public async Task <Region?> GetByIdSync(string id)
        {
            return await myDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> Update(string id,Region region)
        {
            var exist=await myDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null ;
            }
            //Map DTO to domain model
            exist.Code = region.Code;
            exist.RegionImageUrl = region.RegionImageUrl;
            exist.Name = region.Name;
            await myDbContext.SaveChangesAsync();
            return exist;


        }

        
    }
}
