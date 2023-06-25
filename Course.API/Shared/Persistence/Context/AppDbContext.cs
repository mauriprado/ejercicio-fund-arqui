using Microsoft.EntityFrameworkCore;

namespace Course.API.Shared.Persistence.Context;

public class AppDbContext: DbContext
{
    public DbSet<Course.API.Learning.Domain.Models.Course> Courses { set; get; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Learning.Domain.Models.Course>().ToTable("courses");
        builder.Entity<Learning.Domain.Models.Course>().HasKey(p => p.Id);
        builder.Entity<Learning.Domain.Models.Course>().Property(p => p.Id).IsRequired();
        builder.Entity<Learning.Domain.Models.Course>().Property(p => p.Name).IsRequired();
        builder.Entity<Learning.Domain.Models.Course>().Property(p => p.Price).IsRequired();
    }
}