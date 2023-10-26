using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {
        }
        public DbSet<Book> Books { get; set; }
       public DbSet<Student> Students { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
