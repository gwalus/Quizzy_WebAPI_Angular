using QuizzyAPI.Dtos;
using QuizzyAPI.Interfaces;
using QuizzyAPI.TriviaModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzyAPI.Services
{
    public class TriviaService : ITriviaService
    {
        private readonly Lazy<RestClient> client = new Lazy<RestClient>(() => new RestClient("https://opentdb.com/api.php?"));

        public async Task<IList<TriviaCategoriesDto>> GetCategories()
        {
            var request = new RestRequest("https://opentdb.com/api_category.php");

            var response = await client.Value.ExecuteAsync<TriviaCategories>(request);

            if (response.IsSuccessful)
            {
                var categories = response.Data.Trivia_categories;

                var categoriesToReturn = new List<TriviaCategoriesDto>();

                foreach (var category in categories)
                {
                    var requestForTotals = new RestRequest("https://opentdb.com/api_count.php?category")
                        .AddParameter("category", $"{category.Id}");

                    var responseForTotals = await client.Value.ExecuteAsync<CategoriesQuantity>(requestForTotals);

                    if (responseForTotals.IsSuccessful)
                    {
                        var fullCategory = new TriviaCategoriesDto()
                        {
                            Id = category.Id,
                            Name = category.Name,
                            TotalsEasy = responseForTotals.Data.category_question_count.total_easy_question_count,
                            TotalsMedium = responseForTotals.Data.category_question_count.total_medium_question_count,
                            TotalsHard = responseForTotals.Data.category_question_count.total_hard_question_count
                        };

                        categoriesToReturn.Add(fullCategory);
                    }
                }
                return categoriesToReturn;
            }
            return null;
        }

        public async Task<IList<Result>> GetQuestions(string categoryId, string difficulty, string amount = "10", string type = "multiple")
        {
            var request = new RestRequest()
                .AddParameter("category", $"{categoryId}")
                .AddParameter("difficulty", $"{difficulty}")
                .AddParameter("amount", $"{amount}")
                .AddParameter("type", $"{type}");

            var response = await client.Value.ExecuteAsync<TriviaResponse>(request);

            if (response.IsSuccessful)
                return response.Data.results;

            return null;
        }

        public async Task<CategoryQuestionCount> GetCategoriesQuantity(string categoryId)
        {
            var request = new RestRequest("https://opentdb.com/api_count.php?category")
                .AddParameter("category", $"{categoryId}");

            var response = await client.Value.ExecuteAsync<CategoriesQuantity>(request);

            if (response.IsSuccessful)
                return response.Data.category_question_count;

            return null;
        }
    }
}