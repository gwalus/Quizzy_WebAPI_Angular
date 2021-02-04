namespace QuizzyAPI.Dtos
{
    public class LeaderboardsDto
    {
        public string Username { get; set; }
        public string Category { get; set; }
        public string Difficulty { get; set; }
        public int TopScore { get; set; }
    }
}