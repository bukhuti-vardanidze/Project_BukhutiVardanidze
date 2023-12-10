using Microsoft.EntityFrameworkCore;
using Project.DB.Entities;

namespace Project.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
