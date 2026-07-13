using System.Diagnostics.CodeAnalysis;

namespace LeaderboardAPI.DTOs
{
    public class LoginDto
    {
        [NotNull]
        public string UserName { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
