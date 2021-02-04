using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzyAPI.Data;
using QuizzyAPI.Dtos;

namespace QuizzyAPI.Controllers
{
    public class LeaderboardsController : BaseApiController
    {
        private readonly SqliteDbContext _dataContext;
        public LeaderboardsController(SqliteDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("top-categories")]
        public async Task<List<LeaderboardsCategoriesDto>> GetLeaderBoards()
        {
            var leaderboards = await _dataContext.QuizResults
                .GroupBy(c => c.Category)
                .Select(
                    x => new LeaderboardsCategoriesDto
                    {
                        Category = x.Key,
                        Score = x.Max(c => c.Score)
                    }
                )
                .OrderByDescending(x => x.Score)
                .ToListAsync();

            foreach (var item in leaderboards)
            {
                var firstRecord = await _dataContext.QuizResults
                    .Where(x => x.Category == item.Category && x.Score == item.Score).FirstOrDefaultAsync();

                item.Username = firstRecord.Username;
            }

            return leaderboards;
        }

        [HttpGet("leaderboards-top-users")]
        public async Task<List<LeaderboardsTopDto>> GetTopUsersLeaderBoards()
        {
            var leaderboards = await _dataContext.QuizResults
                .GroupBy(u => u.Username)
                .Select(x => new LeaderboardsTopDto
                {
                    Username = x.Key,
                    Totals = x.Sum(s => s.Score)
                })
                .OrderByDescending(s => s.Totals)
                .Take(10)
                .ToListAsync();

            return leaderboards;
        }
    }
}