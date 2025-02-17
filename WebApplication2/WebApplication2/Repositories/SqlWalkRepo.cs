using NZWalks.API.Models.Domain;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication2.Repositories
{
    public class SqlWalkRepo : IWalkRepo
    {
        private readonly MyDbContext myDbContext;

        public SqlWalkRepo(MyDbContext myDbContext) 
        {
            this.myDbContext = myDbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await myDbContext.Walks.AddAsync(walk);
            await myDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteById(int id)
        {
            var exist = await myDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null;
            }
            myDbContext.Walks.Remove(exist);
            await myDbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Walk>> Getal(string? filterOn = null, string? filterQuery = null, string? sortby = null, bool isAscend = true)
        {
            var walk =  myDbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //filtering
            if (string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false) 
            {

                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walk = walk.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //orderby btrtb ascending automatic
            //sorting
            if (string.IsNullOrWhiteSpace(sortby) == false )
            {
                if (sortby.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walk = isAscend ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x => x.Name);
                }
                else if (sortby.Equals("Length", StringComparison.OrdinalIgnoreCase))
                { 
                    walk=isAscend ? walk.OrderBy(x=>x.LengthInKM) : walk.OrderByDescending(x => x.LengthInKM);
                }
            }


            //return await myDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            return await walk.ToListAsync();
        } 

        public async Task<Walk?> GetById(int id)
        {
          return await myDbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> Update(int id ,Walk walk)
        {
           var exist= await myDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null;
            }
            //exist.Difficulty = walk.Difficulty;
            //exist.Id = walk.Id; 
            //exist.Region = walk.Region; 
            exist.Name = walk.Name;
            exist.Description = walk.Description;
            exist.LengthInKM = walk.LengthInKM;
            exist.DifficultyId = walk.DifficultyId;
            exist.RegionId = walk.RegionId;

            await myDbContext.SaveChangesAsync();
            return exist;
        }
    }
}
