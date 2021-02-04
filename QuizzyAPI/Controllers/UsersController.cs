using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzyAPI.Data;
using QuizzyAPI.Dtos;
using QuizzyAPI.Entities;

namespace QuizzyAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly SqliteDbContext _dataContext;
        public UsersController(SqliteDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Authorize]
        [HttpGet("records")]
        public async Task<List<QuizResultDto>> GetRecords(string username, string category)
        {
            var results = new List<QuizResult>();
            var resultsDtos = new List<QuizResultDto>();

            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (category == "All")
            {
                results = user.QuizResults
                .OrderByDescending(s => s.Score)
                .Take(10)
                .ToList();
            }
            else
            {
                results = user.QuizResults
                .Where(c => c.Category == category)
                .OrderByDescending(s => s.Score)
                .Take(10)
                .ToList();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<QuizResult, QuizResultDto>());

            var mapper = new Mapper(config);

            foreach (var resultDto in results)
            {
                var dto = mapper.Map<QuizResultDto>(resultDto);
                resultsDtos.Add(dto);
            }

            return resultsDtos;
        }
    }
}