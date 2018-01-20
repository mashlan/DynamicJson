using System;
using System.Collections.Generic;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Queue : IAssetTrackEntity
    {
        public Guid Id { get; set; }
        public string EntityName { get; set; }
        public ICollection<Context> Contexts { get; set; }
        public ICollection<Entity> Entities { get; set; }
    }
}