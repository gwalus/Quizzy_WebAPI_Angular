using System.Collections.Generic;

namespace QuizzyAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Age { get; set; }
        public virtual ICollection<QuizResult> QuizResults { get; set; }
    }
}