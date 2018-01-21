using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.Domain.Services
{
    public interface IQueueService
    {
        IEnumerable<Queue> GetAll();

        IEnumerable<Queue> Find(Expression<Func<Queue, bool>> expression);

        Queue Single(Expression<Func<Queue, bool>> expression = null);
    }
}
