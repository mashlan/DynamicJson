using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Extentions;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class TaskMockData
    {
        public static IEnumerable<Task> CreateMocks(int count)
        {
            return new Faker<Task>()
                .RuleFor(r => r.Name, f => f.PickRandom(new List<string>{"Move", "Add", "Update", "Remove"}))
                .RuleFor(r => r.Description, f => f.Commerce.ProductName())
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.IsBulk, f => f.PickRandomBoolean())
                .Generate(count);
        }
    }
}