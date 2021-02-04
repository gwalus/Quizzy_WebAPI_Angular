using System.Collections.Generic;
using System.Threading.Tasks;
using QuizzyAPI.Dtos;
using QuizzyAPI.TriviaModels;

namespace QuizzyAPI.Interfaces
{
    public interface ITriviaService
    {
        Task<IList<Result>> GetQuestions(string category, string difficulty, string amount, string type);
        Task<IList<TriviaCategoriesDto>> GetCategories();
        Task<CategoryQuestionCount> GetCategoriesQuantity(string categoryId);
    }
}