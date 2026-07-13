using LeaderboardAPI.DTOs;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Interfaces
{
    public interface IScoreRepository
    {
        Task<Score?> AddScore(CreateScoreDto scoreDto);
        Task<GetScoreDto?> GetPlayerScore(int id);
        Task<List<Score>?> GetAllScores();
    }
}
