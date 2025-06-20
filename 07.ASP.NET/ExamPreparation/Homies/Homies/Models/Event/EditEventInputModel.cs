namespace Homies.Models.Event
{
    using System.ComponentModel.DataAnnotations;

    public class EditEventInputModel : EventAddInputModel
    {
        [Required]
        public int Id { get; set; }
    }
}
