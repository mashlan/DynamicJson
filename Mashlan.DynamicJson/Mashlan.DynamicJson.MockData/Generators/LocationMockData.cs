using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class LocationMockData
    {
        public static IEnumerable<Location> CreateMocks(int count)
        {
            return new Faker<Location>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.ParentLocationId,  f => Guid.NewGuid())
                .RuleFor(r => r.Names, f => f.Address.BuildingNumber())
                .RuleFor(r => r.Codes, f => f.Random.AlphaNumeric(7).ToUpper())
                .Generate(count);
        }
    }
}