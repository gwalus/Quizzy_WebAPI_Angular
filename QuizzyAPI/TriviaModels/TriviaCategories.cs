using System.Collections.Generic;

namespace QuizzyAPI.TriviaModels
{
    public class TriviaCategories
    {
        public IList<TriviaCategory> Trivia_categories { get; set; }
    }

    public class TriviaCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}