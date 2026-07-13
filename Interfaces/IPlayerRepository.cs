using LeaderboardAPI.DTOs;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player?> GetPlayer(int id);
        Task<List<Player>> GetAllPlayers();
        Task<List<Player>> GetAllPlayersWithScore();
        Task<Player?> CreatePlayer(CreatePlayerDto playerDto);
        Task<bool> UpdatePlayer(UpdatePlayerDto updatedPlayer);
        Task<bool> DeletePlayer(int id);
    }
}
