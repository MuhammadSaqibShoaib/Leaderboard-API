using LeaderboardAPI.Data;
using LeaderboardAPI.DTOs;
using LeaderboardAPI.Interfaces;
using LeaderboardAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace LeaderboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService) 
        {
            _scoreService = scoreService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Add Score", Description = "Records a new score entry for a player")]
        public async Task<ActionResult<Score>> AddScore(CreateScoreDto scoreDto)
        {
            Score? score = await _scoreService.AddScore(scoreDto);
            if (score == null) { return BadRequest("Failed to add score"); }
            return CreatedAtAction(nameof(GetPlayerScore), new { id = score.Id }, score);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Leaderboard", Description = "Returns all players ranked by total points")]
        [AllowAnonymous]
        public async Task<ActionResult<List<LeaderboardDto>>> GetLeaderboard()
        {
            
            var ranked = await _scoreService.GetLeaderboard();
            return Ok(ranked);
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Player Scores", Description = "Returns all scores for a specific player")]
        public async Task<ActionResult<List<Score>>> GetPlayerScore(int id)
        {
            var result = await _scoreService.GetPlayerScore(id);

            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
