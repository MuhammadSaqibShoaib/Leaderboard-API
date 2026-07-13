using LeaderboardAPI.DTOs;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Interfaces
{
    public interface IScoreService
    {
        Task<Score?> AddScore(CreateScoreDto createScoreDto);
        Task<GetScoreDto?> GetPlayerScore(int playerrId);
        Task<List<Score>?> GetAllScores();
        Task<List<LeaderboardDto>?> GetLeaderboard();
    }
}
