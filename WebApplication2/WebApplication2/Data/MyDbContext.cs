using System.Data;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using WebApplication1.Models.Domain;
using WebApplication2.Models.Domain;

namespace WebApplication1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed The Data For Difficulties 
            //Easy , Medium , High

            var difficulties = new List<Difficulty>()
            {
                new Difficulty() {
                Id= "111",
                Name="Easy"
                },
                new Difficulty() {
                Id="222",
                Name="Medium"
                },
                new Difficulty() {
                Id="333",
                Name="Hard"
                }

            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id="100",
                    Name="Auckland",
                    Code="Akl",
                    RegionImageUrl="Akl.img"
                },
               new Region()
                {
                    Id="200",
                    Name="Auckland2",
                    Code="Akl2",
                    RegionImageUrl="Akl2.img"
                },
               new Region()
                {
                    Id="300",
                    Name="Auckland3",
                    Code="Akl3",
                    RegionImageUrl="Akl3.img"
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);


        }
    }
}
