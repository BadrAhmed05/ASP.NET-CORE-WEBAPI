using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;

namespace WebApplication2.Data
{
    public class NZWalksAuthDBContext : IdentityDbContext
    {
        public NZWalksAuthDBContext(DbContextOptions<NZWalksAuthDBContext> options) : base(options)
        {

        }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>
            {

                   new IdentityRole()
                   {
                       Id="Hello",
                       ConcurrencyStamp="trying",
                       Name="Bedro",
                       NormalizedName="Bedro".ToUpper()

                   },
                   new IdentityRole()
                   {
                       Id="Hello2",
                       ConcurrencyStamp="trying2",
                       Name="Bedro2",
                       NormalizedName="Bedro2".ToUpper()

                   }

            };
            builder.Entity<IdentityRole>().HasData(roles); 
        }
    }
}
