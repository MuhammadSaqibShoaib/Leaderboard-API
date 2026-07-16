using LeaderboardAPI.Data;
using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Player>>> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayers();
            return Ok(players); // always 200, empty list is fine
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = await _playerService.GetPlayer(id);
            return player is null ? NotFound() : Ok(player); // 404 or 200
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(CreatePlayerDto playerDto)
        {
            var newPlayer = await _playerService.CreatePlayer(playerDto);
            if (newPlayer is not null)
                return CreatedAtAction(nameof(Get), new { id = newPlayer.Id }, newPlayer);
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdatePlayerDto updated)
        {
            var isUpdated = await _playerService.UpdatePlayer(updated);
            if (!isUpdated) return NotFound();
            return NoContent();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id) 
        {
            bool isDeleted = await _playerService.DeletePlayer(id);
            if(!isDeleted) return NotFound();
            return NoContent();
        }

        //[HttpGet("crash")]
        //public async Task<ActionResult> Crash()
        //{
        //    throw new Exception("Something went terribly wrong!");
        //}
    }
}
