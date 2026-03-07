using Microsoft.EntityFrameworkCore;
using CVSystem.Models;

namespace CVSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
    }
}