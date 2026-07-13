using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepo;
        private readonly IPlayerRepository _playerRepo;
        public ScoreService(IPlayerRepository playerRepository, IScoreRepository scoreRepo)
        {
            _playerRepo = playerRepository;
            _scoreRepo = scoreRepo;
        }
        public Task<Score?> AddScore(CreateScoreDto createScoreDto)
        {
            return _scoreRepo.AddScore(createScoreDto);
        }

        public Task<List<Score>?> GetAllScores()
        {
            return _scoreRepo.GetAllScores();
        }

        public async Task<List<LeaderboardDto>?> GetLeaderboard()
        {
            var playersWithScores = await _playerRepo.GetAllPlayersWithScore();

            var leaderboard = playersWithScores.Select(p => new LeaderboardDto
            {
                PlayerName = p.PlayerName,
                TotalPoints = p.Scores.Sum(s => s.Points)  
                                                           
            }).OrderByDescending(x => x.TotalPoints).ToList();

            var ranked = leaderboard.Select((p, index) => new LeaderboardDto
            {
                Rank = index + 1,
                PlayerName = p.PlayerName,
                TotalPoints = p.TotalPoints
            }).ToList();

            return ranked;
        }

        public Task<GetScoreDto?> GetPlayerScore(int playerrId)
        {
            return _scoreRepo.GetPlayerScore(playerrId);
        }
    }
}
