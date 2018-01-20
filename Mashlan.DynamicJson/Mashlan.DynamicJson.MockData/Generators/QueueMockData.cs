using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class QueueMockData
    {
        public static IEnumerable<Queue> CreateMocks(int count)
        {
            return new Faker<Queue>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.EntityName, f => f.PickRandom(new List<string>{"Assets", "Forms", "Tasks"}))
                .Generate(count);
        }
    }
}