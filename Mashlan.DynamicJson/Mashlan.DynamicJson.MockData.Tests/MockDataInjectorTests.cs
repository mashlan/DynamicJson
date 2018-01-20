using System;
using System.Linq;
using FluentAssertions;
using Mashlan.DynamicJson.DataAccess;
using Mashlan.DynamicJson.Domain.DataContext;
using Mashlan.DynamicJson.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Mashlan.DynamicJson.MockData.Tests
{
    public class MockDataInjectorTests : IDisposable
    {
        private IAssetTrackContext context;
        private MockDataInjector mockDataInjector;

        public MockDataInjectorTests()
        {
            var options = new DbContextOptionsBuilder<AssetTrackContext>()
                .UseInMemoryDatabase("Mashlan.DynamicJson")
                .Options;

            context = new AssetTrackContext(options);
            mockDataInjector = new MockDataInjector(context);
        }

        public void Dispose()
        {
            context = null;
            mockDataInjector = null;
        }

        [Fact]
        public void GetLocationMockData()
        {
            var locationList = mockDataInjector.Locations;
            var enumerable = locationList as Location[] ?? locationList.ToArray();
            
            enumerable.Should().NotBeNull();
            enumerable.Count().ShouldBeEquivalentTo(1000);
        }

        [Fact]
        public void ContextLocationShouldAddRange()
        {
            mockDataInjector.InjectAllAsync();

            context.Locations.Local.Should().NotBeNull();
            context.Locations.Local.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void GetAssigneeMockData()
        {
            var assigneeList = mockDataInjector.Assignees;
            var enumerable = assigneeList as Assignee[] ?? assigneeList.ToArray();

            enumerable.Should().NotBeNull();
            enumerable.Length.ShouldBeEquivalentTo(100);
        }

        [Fact]
        public void ContextAssigneeShouldAddRange()
        {
            mockDataInjector.InjectAllAsync();
            context.Assignees.Local.Should().NotBeNull();
            context.Assignees.Local.Count.Should().BeGreaterThan(0);
        }

        
    }
}
