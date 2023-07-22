using DMAWS_T2203E_VUHOANGANH.Models;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2203E_VUHOANGANH.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Add this constructor to pass the database connection string
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for entities
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
