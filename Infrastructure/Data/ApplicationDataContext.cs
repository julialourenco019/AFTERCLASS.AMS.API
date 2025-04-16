using Microsoft.EntityFrameworkCore;
using AFTERCLASS.AMS.API.Domain.Entities;

namespace AFTERCLASS.AMS.API.Infrastructure.Data;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

    public DbSet<Teacher> Teacher { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasKey(t => t.Id);
    }
}
