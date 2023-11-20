using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class DBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/PostItBaseNoForeignKey.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Post>()
            .HasKey(post => post.Id);

        modelBuilder.Entity<User>()
            .HasKey(user => user.username);
        
    }
    
}