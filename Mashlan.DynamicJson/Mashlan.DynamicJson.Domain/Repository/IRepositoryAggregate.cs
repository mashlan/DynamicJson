using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.Domain.Repository
{
    public interface IRepositoryAggregate
    {
        IRepository<Assignee> Assignees { get; }
        IRepository<Context> Contexts { get; }
        IRepository<Entity> Entities { get; }
        IRepository<FormTask> FormTasks { get; }
        IRepository<Location> Locations { get; }
        IRepository<Page> Pages { get; }
        IRepository<Product> Products{get;}
        IRepository<Queue> Queues { get; }
        IRepository<Task> Tasks { get; }
        IRepository<User> Users { get; }
    }
}