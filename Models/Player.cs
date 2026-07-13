namespace LeaderboardAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public String PlayerName { get; set; }
        public List<Score> Scores { get; set; } = new List<Score>();
    }
}
