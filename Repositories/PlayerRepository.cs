using LeaderboardAPI.Data;
using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardAPI.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _db;
        public PlayerRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Player?> CreatePlayer(CreatePlayerDto playerDto)
        {
            Player newPlayer = new Player()
            {
                PlayerName = playerDto.PlayerName
            };
            _db.Players.Add(newPlayer);
            await _db.SaveChangesAsync();
            return newPlayer;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null)
            {
                return false;
            }
            _db.Players.Remove(player);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var playerList = await _db.Players.ToListAsync();
            return playerList;
        }

        public async Task<List<Player>> GetAllPlayersWithScore()
        {
            var playerList = await _db.Players.Include(p=>p.Scores).ToListAsync();
            return playerList;
        }

        public async Task<Player?> GetPlayer(int id)
        {
            var player = await _db.Players.FindAsync(id);
            return player;
        }

        public async Task<bool> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            var player = await _db.Players.FindAsync(updatedPlayer.Id);
            if (player != null)
            {
                player.PlayerName = updatedPlayer.PlayerName;
                _db.Update(player);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
