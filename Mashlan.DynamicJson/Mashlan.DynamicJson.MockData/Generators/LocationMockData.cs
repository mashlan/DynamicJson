using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class LocationMockData
    {
        public static IEnumerable<Location> CreateMocks(int count)
        {
            return new Faker<Location>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.LocationsGuids, f => new List<string> {Guid.NewGuid().ToString(), Guid.NewGuid().ToString()})
                .RuleFor(r => r.ParentLocationGuids, f => new List<string>{Guid.NewGuid().ToString(), Guid.NewGuid().ToString()})
                .RuleFor(r => r.Names, f => new []{f.Company.CompanyName(), f.Company.CompanyName()})
                .RuleFor(r => r.Codes, f => new List<string> {f.Commerce.ProductName(), f.Commerce.ProductName()})
                .Generate(count);
        }
    }
}