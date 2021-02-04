namespace QuizzyAPI.Entities
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Category { get; set; }
        public string Difficulty { get; set; }
        public int Score { get; set; }
    }
}