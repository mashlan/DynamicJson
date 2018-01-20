using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class AssigneeMockData
    {
        public static IEnumerable<Assignee> CreateMocks(int count, IEnumerable<Location> locations)
        {
            return new Faker<Assignee>()
                .StrictMode(true)
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(r => r.FirstName, f => f.Name.FirstName())
                .RuleFor(r => r.LastName, f => f.Name.LastName())
                .RuleFor(r => r.Location, f => f.PickRandom(locations))
                .RuleFor(r => r.Code, f => f.Commerce.ProductName())
                .RuleFor(r => r.MiddleInitial,
                    f => f.PickRandom(new List<char> {'A', 'B', 'C', 'D', 'E', 'Z'}).ToString())
                .RuleFor(r => r.IsActive, f => f.PickRandom(new List<bool> {true, false}))
                .Generate(count);
        }
    }
}