namespace WebApplication2.Models.Domain.DTO
{
    public class UpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public string? WalkImageId { get; set; }

        public string DifficultyId { get; set; }
        public string RegionId { get; set; }
    }
}
