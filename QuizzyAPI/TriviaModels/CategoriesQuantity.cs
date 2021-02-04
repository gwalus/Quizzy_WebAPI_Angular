namespace QuizzyAPI.TriviaModels
{
    public class CategoriesQuantity
    {
        public int category_id { get; set; }
        public CategoryQuestionCount category_question_count { get; set; }
    }

    public class CategoryQuestionCount
    {
        public int total_question_count { get; set; }
        public int total_easy_question_count { get; set; }
        public int total_medium_question_count { get; set; }
        public int total_hard_question_count { get; set; }
    }
}