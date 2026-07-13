using System.ComponentModel.DataAnnotations;

namespace LeaderboardAPI.DTOs
{
    public class CreateScoreDto
    {
        [Required]
        public int PlayerId { get; set; }
        [Range(0, 1000,ErrorMessage ="Points must be between 0-1000")]
        public int Points { get; set; }
    }
}
