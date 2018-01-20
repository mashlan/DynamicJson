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
                .StrictMode(true)
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.LocationsGuids, f => new List<Guid> {Guid.NewGuid(), Guid.NewGuid()})
                .RuleFor(r => r.ParentLocationGuids, f => new List<Guid> {Guid.NewGuid(), Guid.NewGuid()})
                .RuleFor(r => r.Names, f => new List<string> {f.Company.CompanyName(), f.Company.CompanyName()})
                .RuleFor(r => r.Codes, f => new List<string> {f.Commerce.ProductName(), f.Commerce.ProductName()})
                .Generate(count);

            
        }
    }
}