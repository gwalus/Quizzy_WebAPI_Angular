using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzyAPI.Data;
using QuizzyAPI.Dtos;
using QuizzyAPI.Entities;
using QuizzyAPI.Interfaces;
using QuizzyAPI.TriviaModels;

namespace QuizzyAPI.Controllers
{
    public class TriviaController : BaseApiController
    {
        private readonly ITriviaService _triviaService;
        private readonly SqliteDbContext _dataContext;
        public TriviaController(ITriviaService triviaService, SqliteDbContext dataContext)
        {
            _dataContext = dataContext;
            _triviaService = triviaService;
        }

        [HttpGet("getcategories")]
        public async Task<IList<TriviaCategoriesDto>> GetCategories()
        {
            var categories = await _triviaService.GetCategories();

            return categories;
        }

        [HttpGet("getquestionsbycategory/{categoryId}/{difficulty}")]
        public async Task<IList<Result>> GetQuestions(string categoryId, string difficulty)
        {
            var questions = await _triviaService.GetQuestions(categoryId, difficulty, "10", "multiple");

            return questions;
        }

        [HttpPost("save")]
        public async Task<bool> SaveScore(QuizResult quizResult)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserName == quizResult.Username);

            if (user == null) return false;

            user.QuizResults.Add(quizResult);
            if (await _dataContext.SaveChangesAsync() > 0)
                return true;

            return false;
        }
    }
}