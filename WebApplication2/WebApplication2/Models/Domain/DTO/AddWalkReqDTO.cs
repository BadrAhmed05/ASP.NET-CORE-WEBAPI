using NZWalks.API.Models.Domain;
using WebApplication1.Models.Domain;

namespace WebApplication2.Models.Domain.DTO
{
    public class AddWalkReqDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageId { get; set; }

        public string DifficultyId { get; set; }
        public string RegionId { get; set; }

        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }
    }
}
