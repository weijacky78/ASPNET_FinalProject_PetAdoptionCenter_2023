using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FinalProject.Models;

public class ProjectContext : IdentityDbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) //empty constructor
        : base(options)
    {
    }
    public DbSet<Pet> Pets { get; set; } = default!;
}
