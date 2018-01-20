using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Extentions;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class AssigneeMockData
    {
        public static IEnumerable<Assignee> CreateMocks(int count)
        {
            return new Faker<Assignee>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(r => r.FirstName, f => f.Name.FirstName())
                .RuleFor(r => r.LastName, f => f.Name.LastName())
                .RuleFor(r => r.Code, f => f.Commerce.ProductName())
                .RuleFor(r => r.MiddleInitial, f => f.PickRandomCharacter())
                .RuleFor(r => r.IsActive, f => f.PickRandomBoolean())
                .Generate(count);
        }
    }
}