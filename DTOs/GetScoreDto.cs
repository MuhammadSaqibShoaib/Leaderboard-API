namespace LeaderboardAPI.DTOs
{
    public class GetScoreDto
    {
        public string PlayerName { get; set; }
        public List<ScoreEntryDto> Scores { get; set; }
    }
}
