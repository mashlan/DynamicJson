using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Mashlan.DynamicJson.Domain.DataContext;
using Mashlan.DynamicJson.Domain.Entities;
using Mashlan.DynamicJson.MockData.Generators;

namespace Mashlan.DynamicJson.MockData
{
    public class MockDataInjector
    {
        private readonly IAssetTrackContext context;
        private IEnumerable<Assignee> assignees;
        private IEnumerable<Location> locations;

        public MockDataInjector(IAssetTrackContext context)
        {
            this.context = context;
        }

        public async void InjectAllAsync()
        {
            Randomizer.Seed = new Random(8675309);

            await context.Locations.AddRangeAsync(Locations);
            await context.Assignees.AddRangeAsync(Assignees);

        }

        public  IEnumerable<Assignee> Assignees => assignees ?? (assignees = AssigneeMockData.CreateMocks(100, Locations));

        public IEnumerable<Location> Locations => locations ?? (locations = LocationMockData.CreateMocks(1000));

        

        

    }
}
