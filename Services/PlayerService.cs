using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;

namespace LeaderboardAPI.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepo;

        public PlayerService(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public async Task<Player?> CreatePlayer(CreatePlayerDto player)
        {
            return await _playerRepo.CreatePlayer(player);
        }

        public Task<bool> DeletePlayer(int id)
        {
            return _playerRepo.DeletePlayer(id);
        }

        public Task<List<Player>> GetAllPlayers()
        {
            return _playerRepo.GetAllPlayers();
        }


        public async Task<Player?> GetPlayer(int id)
        {
            return await _playerRepo.GetPlayer(id);
        }

        public Task<bool> UpdatePlayer(UpdatePlayerDto player)
        {
            return _playerRepo.UpdatePlayer(player);
        }
    }
}
