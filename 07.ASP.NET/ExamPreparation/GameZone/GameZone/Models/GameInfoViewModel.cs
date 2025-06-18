namespace GameZone.Models
{
    public class GameInfoViewModel
    {
        public int Id { get; set; }

        public required string Title { get; set; } // required properties from EF Core 8

        public string? ImageUrl { get; set; }

        public required string Genre { get; set; }

        public required string ReleasedOn { get; set; }

        public required string Publisher { get; set; }
    }
}
