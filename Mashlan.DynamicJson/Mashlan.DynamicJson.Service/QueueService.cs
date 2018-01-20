using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.Domain.Repository;
using Mashlan.DynamicJson.Domain.Services;

namespace Mashlan.DynamicJson.Service
{
    public class QueueService : IQueueService
    {
        private readonly IRepositoryAggregate repositoryAggregate;

        public QueueService(IRepositoryAggregate repositoryAggregate)
        {
            this.repositoryAggregate = repositoryAggregate;
        }

        public IEnumerable<Queue> GetAll()
        {
            return repositoryAggregate.Queues.GetAll();
        }

        public IEnumerable<Queue> Find(Expression<Func<Queue, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Queue Single(Expression<Func<Queue, bool>> expression = null)
        {
            var queue = repositoryAggregate.Queues.GetAll().First();
            queue.Entities = GetEntities();
            queue.Contexts = GetContext();

            return queue;
        }

        private List<Entity> GetEntities()
        {
            var entities = repositoryAggregate.Entities.GetAll().Take(20).ToList();
            foreach (var entity in entities)
            {
                entity.Location = repositoryAggregate.Locations.GetAll().First();
                entity.Assignee = repositoryAggregate.Assignees.GetAll().First();
                entity.Assignee.Location = entity.Location;
                entity.Product = repositoryAggregate.Products.GetAll().First();
            }

            return entities;
        }

        private List<Context> GetContext()
        {
            var contexts = repositoryAggregate.Contexts.GetAll().Take(2).ToList();
            foreach (var context in contexts)
            {
                context.Task = repositoryAggregate.Tasks.GetAll().First();
            }

            return contexts;
        }
    }
}
