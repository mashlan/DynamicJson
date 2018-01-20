using Mashlan.DynamicJson.Domain.DataContext;
using Mashlan.DynamicJson.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mashlan.DynamicJson.DataAccess
{
    public class AssetTrackContext : DbContext, IAssetTrackContext
    {
        public AssetTrackContext(DbContextOptions options) : base(options) { }

        public DbSet<Assignee> Assignees { get; set; }
        public DbSet<Context> Contexts { get;set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<FormTask> FormTasks{get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get;set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignee>().ToTable(nameof(Assignee)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Context>().ToTable(nameof(Context)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Entity>().ToTable(nameof(Entity)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<FormTask>().ToTable(nameof(FormTask)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().ToTable(nameof(Location));
            modelBuilder.Entity<Page>().ToTable(nameof(Page)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().ToTable(nameof(Product)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Queue>().ToTable(nameof(Queue));
            modelBuilder.Entity<Task>().ToTable(nameof(Task)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().ToTable(nameof(User)).Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }

}
