using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Mashlan.DynamicJson.Domain.DataContext;
using Mashlan.DynamicJson.Domain.Entities;

namespace Mashlan.DynamicJson.MockData
{
    public class MockDataInjector
    {

        public static async void InjectAsync(IAssetTrackContext context)
        {
            Randomizer.Seed = new Random(8675309);
            await InitializeAssigneeAsync(context);

        }

        private static async Task<IEnumerable<Assignee>> InitializeAssigneeAsync(IAssetTrackContext context)
        {
            var locations = InitializeLocationAsync(context);

            var assignees = new Faker<Assignee>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(r => r.FirstName, f => f.Name.FirstName())
                .RuleFor(r => r.LastName, f => f.Name.LastName());
               // .RuleFor(r => r.Location, f => f.PickRandom(locations.Result))
               // .RuleFor(r => r.Code, f => f.Commerce.ProductName())
               // .RuleFor(r => r.MiddleInitial, f => f.PickRandom(new List<char> {'A', 'B', 'C', 'D', 'E', 'Z'}).ToString())
               // .RuleFor(r => r.IsActive, f => f.PickRandom(new List<bool> {true, false}));

            var assigneeList = assignees.Generate(100);
            await context.Assignees.AddRangeAsync(assigneeList);

            return assigneeList;

        }

        private static async  Task<IEnumerable<Location>> InitializeLocationAsync(IAssetTrackContext context)
        {
            var location = new Faker<Location>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.LocationsGuids, f => new List<Guid> {f.PickRandom<Guid>(), f.PickRandom<Guid>()})
                .RuleFor(r => r.ParentLocationGuids, f => new List<Guid> {f.PickRandom<Guid>(), f.PickRandom<Guid>()})
                .RuleFor(r => r.Names, f => new List<string> {f.Company.CompanyName(), f.Company.CompanyName()})
                .RuleFor(r => r.Codes, f => new List<string> {f.Commerce.ProductName(), f.Commerce.ProductName()});

            var locations = location.Generate(1000);
            await context.Locations.AddRangeAsync(locations);

            return locations;
        }

    }
}
