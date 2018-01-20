using Mashlan.DynamicJson.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mashlan.DynamicJson.Domain.DataContext
{
    public interface IAssetTrackContext
    {
        DbSet<Assignee> Assignees { get; set; }
        DbSet<Context> Contexts { get;set; }
        DbSet<Entity> Entities { get; set; }
        DbSet<FormTask> FormTasks{get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Queue> Queues { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get;set; }
    }
}
