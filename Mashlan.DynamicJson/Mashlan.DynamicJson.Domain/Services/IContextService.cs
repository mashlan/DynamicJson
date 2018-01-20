using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mashlan.DynamicJson.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace Mashlan.DynamicJson.Domain.Services
{
    public interface IContextService
    {

        IEnumerable<Context> GetAll();

        Context Single(Expression<Func<Context, bool>> expression = null);

        Context Find(Expression<Func<Context, bool>> expression);

        JObject AsJObject();
    }
}