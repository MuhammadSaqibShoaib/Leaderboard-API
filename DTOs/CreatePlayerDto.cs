using System.ComponentModel.DataAnnotations;

namespace LeaderboardAPI.DTOs
{
    public class CreatePlayerDto
    {
        [Required]
        [StringLength(32, MinimumLength =2, ErrorMessage ="The length of player name should be between 2-32")]
        public string PlayerName { get; set; }
    }
}
