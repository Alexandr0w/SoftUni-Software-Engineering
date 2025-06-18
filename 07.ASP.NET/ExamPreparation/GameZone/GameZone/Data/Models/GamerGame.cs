namespace GameZone.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GamerGame
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Gamer))]
        public string GamerId { get; set; } = null!;
        public virtual IdentityUser Gamer { get; set; } = null!;
    }
}
