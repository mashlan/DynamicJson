using System;
using Mashlan.DynamicJson.DataAccess;
using Mashlan.DynamicJson.DataAccess.Repository;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Mashlan.DynamicJson.DependanceInjection
{
    public static class RepositoriesConfiguration
    {
        public static void Configure(IServiceCollection services)
        {

            services.AddTransient<IRepository<Assignee>, Repository<Assignee>>(InitializeReposiotry<Assignee>());
            services.AddTransient<IRepository<Context>, Repository<Context>>(InitializeReposiotry<Context>());
            services.AddTransient<IRepository<Entity>, Repository<Entity>>(InitializeReposiotry<Entity>());
            services.AddTransient<IRepository<FormTask>, Repository<FormTask>>(InitializeReposiotry<FormTask>());
            services.AddTransient<IRepository<Location>, Repository<Location>>(InitializeReposiotry<Location>());
            services.AddTransient<IRepository<Page>, Repository<Page>>(InitializeReposiotry<Page>());
            services.AddTransient<IRepository<Product>, Repository<Product>>(InitializeReposiotry<Product>());
            services.AddTransient<IRepository<Queue>, Repository<Queue>>(InitializeReposiotry<Queue>());
            services.AddTransient<IRepository<Task>, Repository<Task>>(InitializeReposiotry<Task>());
            services.AddTransient<IRepository<User>, Repository<User>>(InitializeReposiotry<User>());

            services.AddTransient<IRepositoryAggregate, RepositoryAggregate>();
        }


        private static Func<IServiceProvider, Repository<TEntity>> InitializeReposiotry<TEntity>() where TEntity : class, IAssetTrackEntity
        {
            return context =>
            {
                DbContext dbContext = context.GetService<AssetTrackContext>();
                return new Repository<TEntity>(dbContext);
            };
        }
        
    }
}
