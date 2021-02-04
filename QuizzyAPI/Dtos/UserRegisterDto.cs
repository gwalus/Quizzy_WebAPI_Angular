namespace QuizzyAPI.Dtos
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public int Age { get; set; }
    }
}