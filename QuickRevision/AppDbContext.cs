using Microsoft.EntityFrameworkCore;
using QuickRevision.Entities;

namespace QuickRevision;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{ 

    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Dep> Dep { get; set; }
    public DbSet<Dev> Dev { get; set; }

}
