namespace Horizons.Web.ViewModels.Destination
{
    using System.ComponentModel.DataAnnotations;

    public class EditDestinationInputModel : AddDestinationInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PublisherId { get; set; } = null!;
    }
}
