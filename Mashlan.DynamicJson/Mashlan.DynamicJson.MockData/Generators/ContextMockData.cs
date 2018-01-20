using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class ContextMockData
    {
        public static IEnumerable<Context> CreateMocks(int count)
        {
            return new Faker<Context>()
                .RuleFor(r => r.Application, f => f.PickRandom(new List<string>{"SmartClient", "DumbClient", "SuperClient"}))
                .RuleFor(r => r.Created, f => f.Date.Past(2))
                .RuleFor(r => r.DateCollected, f => f.Date.Past())
                .RuleFor(r => r.Id,f => Guid.NewGuid())
                .RuleFor(r => r.Updated, f => f.Date.Recent())
                .Generate(count);
        }
    }
}