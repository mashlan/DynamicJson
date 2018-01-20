using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.DataAccess;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Generators;

namespace Mashlan.DynamicJson.MockData
{
    /// <summary>
    /// Mock Data generator for creating in-memory database and for 
    /// stand alone test data.
    /// </summary>
    public class MockDataInjector
    {
        private readonly AssetTrackContext context;

        private IEnumerable<Assignee> assignees;
        private IEnumerable<Context> contexts;
        private IEnumerable<Entity> entities;
        private IEnumerable<Location> locations;
        private IEnumerable<Product> products;
        private IEnumerable<Queue> queues;
        private IEnumerable<Task> tasks;
        private IEnumerable<User> users;
        
        public MockDataInjector(AssetTrackContext context)
        {
            this.context = context;
            Randomizer.Seed = new Random(8675309);
        }

        /// <summary>
        /// Adds all mock data to the Database Context for use in in-memory database
        /// </summary>
        public void InjectAllAsync()
        {
            context.Locations.AddRange(Locations);
            context.Assignees.AddRange(Assignees);
            context.Contexts.AddRange(Contexts);
            context.Entities.AddRange(Entities);
            context.Products.AddRange(Products);
            context.Queues.AddRange(Queues);
            context.Tasks.AddRange(Tasks);
            context.Users.AddRange(Users);

            context.SaveChanges();
        }

        /// <summary>
        /// Gets Assignee Mock Data without adding to the Database Context.
        /// </summary>
        public  IEnumerable<Assignee> Assignees => assignees ?? (assignees = AssigneeMockData.CreateMocks(100));

        /// <summary>
        /// Gets Context Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Context> Contexts => contexts ?? (contexts = ContextMockData.CreateMocks(10));

        /// <summary>
        /// Gets Entity Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Entity> Entities => entities ?? (entities = EntityMockData.CreateMocks(1000));

        /// <summary>
        /// Gets Location Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Location> Locations => locations ?? (locations = LocationMockData.CreateMocks(1000));

        /// <summary>
        /// Gets Product Mock data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Product> Products => products ?? (products = ProductMockData.CreateMocks(1000));

        /// <summary>
        /// Gets Queue Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Queue> Queues => queues ?? (queues = QueueMockData.CreateMocks(10));

        /// <summary>
        /// Gets Task Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<Task> Tasks => tasks ?? (tasks = TaskMockData.CreateMocks(100));

        /// <summary>
        /// Gets User Mock Data without adding to the Database Context.
        /// </summary>
        public IEnumerable<User> Users => users ?? (users = UserMockData.CreateMocks(100));
    }
}
