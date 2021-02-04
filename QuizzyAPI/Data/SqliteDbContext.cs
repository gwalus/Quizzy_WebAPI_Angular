using Microsoft.EntityFrameworkCore;
using QuizzyAPI.Entities;

namespace QuizzyAPI.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
    }
}