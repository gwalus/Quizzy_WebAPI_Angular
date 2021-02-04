using QuizzyAPI.Entities;

namespace QuizzyAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}