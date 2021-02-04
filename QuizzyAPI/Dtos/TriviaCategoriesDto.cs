namespace QuizzyAPI.Dtos
{
    public class TriviaCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalsEasy { get; set; }
        public int TotalsMedium { get; set; }
        public int TotalsHard { get; set; }
    }
}