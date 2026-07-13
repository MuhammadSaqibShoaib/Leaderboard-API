using LeaderboardAPI.DTOs;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Interfaces
{
    public interface IPlayerService
    {
        Task<Player?> GetPlayer(int id);
        Task<List<Player>> GetAllPlayers();
        Task<Player?> CreatePlayer(CreatePlayerDto player);
        Task<bool> UpdatePlayer(UpdatePlayerDto player);
        Task<bool> DeletePlayer(int id);
    }
}
