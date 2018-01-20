using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Extentions;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class ProductMockData
    {
        public static IEnumerable<Product> CreateMocks(int count)
        {
            return new Faker<Product>()
                .RuleFor(r => r.Name, f => f.Commerce.ProductName())
                .RuleFor(r => r.DateModified, f => f.Date.Recent())
                .RuleFor(r => r.Description, f => f.Commerce.Product())
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.IsActive, f => f.PickRandomBoolean())
                .RuleFor(r => r.ManufacturerId, f => Guid.NewGuid())
                .RuleFor(r => r.PartControlNumber, f => f.Random.AlphaNumeric(15).ToUpper())
                .Generate(count);
        }
    }
}