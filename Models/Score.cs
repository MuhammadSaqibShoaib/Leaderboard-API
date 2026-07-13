using LeaderboardAPI.DTOs;

namespace LeaderboardAPI.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player PlayerRef { get; set; }
        public int Points { get; set; }
        public DateTime PlayedAt { get; set; }

        public Score() { }
        public Score(CreateScoreDto scoreDto)
        {
            this.PlayerId = scoreDto.PlayerId;
            this.Points = scoreDto.Points;
            this.PlayedAt = DateTime.UtcNow;
        }
    }
}
