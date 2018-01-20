using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Extentions;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class UserMockData
    {
        public static IEnumerable<User> CreateMocks(int count)
        {
            return new Faker<User>()
                .RuleFor(r => r.FirstName, f => f.Person.FirstName)
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.LastName, f => f.Person.LastName)
                .RuleFor(r => r.MiddleInitial, f => f.PickRandomCharacter())
                .Generate(count);
        }
    }
}