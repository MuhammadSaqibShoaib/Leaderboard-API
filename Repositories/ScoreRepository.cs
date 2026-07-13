using LeaderboardAPI.Data;
using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LeaderboardAPI.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly AppDbContext _db;

        public ScoreRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Score?> AddScore(CreateScoreDto scoreDto)
        {
            Score newScore = new Score(scoreDto);
            _db.Add(newScore);
            await _db.SaveChangesAsync();
            return newScore;
        }

        public async Task<List<Score>?> GetAllScores()
        {
            var scores = await _db.Scores.ToListAsync();
            return scores;
        }

        public async Task<GetScoreDto?> GetPlayerScore(int id)
        {
            var result = await _db.Players
                .Include(p => p.Scores)
                .Where(p => p.Id == id)
                .Select(p => new GetScoreDto
                {
                    PlayerName = p.PlayerName,
                    Scores = p.Scores
                        .OrderByDescending(s => s.PlayedAt)
                        .Select(s => new ScoreEntryDto
                        {
                            Points = s.Points,        // s is individual score
                            PlayedAt = s.PlayedAt
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return result; // null if player not found
        }
    }
}
