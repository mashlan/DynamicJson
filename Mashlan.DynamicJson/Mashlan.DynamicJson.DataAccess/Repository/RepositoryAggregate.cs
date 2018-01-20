using System;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mashlan.DynamicJson.DataAccess.Repository
{
    public class RepositoryAggregate : IRepositoryAggregate
    {
        private readonly DbContext dbContext;
        private IRepository<Assignee> assignees;
        private IRepository<Context> contexts;
        private IRepository<Entity> entities;
        private IRepository<FormTask> formTasks;
        private IRepository<Location> locations;
        private IRepository<Page> pages;
        private IRepository<Product> products;
        private IRepository<Queue> queues;
        private IRepository<Task> tasks;
        private IRepository<User> users;

        public RepositoryAggregate(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException($"{nameof(dbContext)} cannot be null.");
        }

        public IRepository<Assignee> Assignees => assignees ?? (assignees = new Repository<Assignee>(dbContext));

        public IRepository<Context> Contexts => contexts ?? (contexts = new Repository<Context>(dbContext));

        public IRepository<Entity> Entities => entities ?? (entities = new Repository<Entity>(dbContext));

        public IRepository<FormTask> FormTasks => formTasks ?? (formTasks = new Repository<FormTask>(dbContext));

        public IRepository<Location> Locations => locations ?? (locations = new Repository<Location>(dbContext));

        public IRepository<Page> Pages => pages ?? (pages = new Repository<Page>(dbContext));

        public IRepository<Product> Products => products ?? (products = new Repository<Product>(dbContext));

        public IRepository<Queue> Queues => queues ?? (queues = new Repository<Queue>(dbContext));

        public IRepository<Task> Tasks => tasks ?? (tasks = new Repository<Task>(dbContext));

        public IRepository<User> Users => users ?? (users = new Repository<User>(dbContext));
    }
}