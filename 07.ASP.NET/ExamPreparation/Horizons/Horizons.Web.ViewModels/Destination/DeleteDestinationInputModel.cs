namespace Horizons.Web.ViewModels.Destination
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteDestinationInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Publisher { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;
    }
}
