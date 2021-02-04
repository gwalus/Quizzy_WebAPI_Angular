using System.Collections.Generic;

namespace QuizzyAPI.TriviaModels
{
    public class TriviaResponse
    {
        public int response_code { get; set; }
        public IList<Result> results { get; set; }
    }

    public class Result
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public IList<string> incorrect_answers { get; set; }
    }
}