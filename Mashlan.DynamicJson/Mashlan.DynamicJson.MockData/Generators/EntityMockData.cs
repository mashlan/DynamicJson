using System;
using System.Collections.Generic;
using Bogus;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Extentions;

namespace Mashlan.DynamicJson.MockData.Generators
{
    internal class EntityMockData
    {
        public static IEnumerable<Entity> CreateMocks(int count)
        {
            return new Faker<Entity>()
                .RuleFor(r => r.AssetId, f => Guid.NewGuid())
                .RuleFor(r => r.AssetTag, f => f.Random.AlphaNumeric(8).ToUpper())
                .RuleFor(r => r.CollectionContextId, f => Guid.NewGuid())
                .RuleFor(r => r.Created, f => f.Date.Past())
                .RuleFor(r => r.EntityValues, f => string.Empty)
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.IsActive, f => f.PickRandomBoolean())
                .RuleFor(r => r.MacAddress, f => f.Random.AlphaNumeric(14).ToUpper())
                .RuleFor(r => r.PONumber, f => f.Random.AlphaNumeric(10).ToUpper())
                .RuleFor(r => r.SerialNumber, f => f.Random.AlphaNumeric(7).ToUpper())
                .RuleFor(r => r.Status, f => f.PickRandom(new List<string>{"Installed", "Sold", "Broken", "Drunk"}))
                .Generate(count);
        }
    }
}