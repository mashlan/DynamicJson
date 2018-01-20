using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.Domain.Repository
{
    public interface IRepositoryAggregateAsync
    {
        IRepositoryAsync<Assignee> Assignees { get; }
        IRepositoryAsync<Context> Contexts { get; }
        IRepositoryAsync<Entity> Entities { get; }
        IRepositoryAsync<FormTask> FormTasks { get; }
        IRepositoryAsync<Location> Locations { get; }
        IRepositoryAsync<Page> Pages { get; }
        IRepositoryAsync<Product> Products{get;}
        IRepositoryAsync<Queue> Queues { get; }
        IRepositoryAsync<Task> Tasks { get; }
        IRepositoryAsync<User> Users { get; }
    }
}