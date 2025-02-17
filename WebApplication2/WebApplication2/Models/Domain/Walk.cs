using WebApplication1.Models.Domain;

namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageId { get; set; }

        public string DifficultyId { get; set; }
        public string RegionId { get; set; }



        // Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }


    }
}
