using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.Domain.Repository;
using Mashlan.DynamicJson.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mashlan.DynamicJson.Service
{
    public class ContextService : IContextService
    {
        private readonly IRepositoryAggregate repositoryAggregate;
        
        public ContextService(IRepositoryAggregate repositoryAggregate)
        {
            this.repositoryAggregate = repositoryAggregate;
        }

        public IEnumerable<Context> GetAll()
        {
            throw new NotImplementedException();
        }

        public Context Single(Expression<Func<Context, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Context Find(Expression<Func<Context, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public JObject AsJObject()
        {
            
            var jo = new JObject();
            var contexts = repositoryAggregate.Contexts.GetAll().Take(2);
            foreach (var context in contexts)
            {
                SetTask(context);
                SetUser(context);
                jo[context.Id.ToString()] = JToken.Parse(JsonConvert.SerializeObject(context));
            }

            return new JObject {["Contexts"] = jo};

        }

        private void SetTask(Context context)
        {
            context.Task = repositoryAggregate.Tasks.GetAll().First();
        }

        private void SetUser(Context context)
        {
            context.CollectingUser = repositoryAggregate.Users.GetAll().First();
        }
    }
}