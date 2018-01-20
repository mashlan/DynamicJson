using System;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Task : IAssetTrackEntity
    {
        [JsonProperty("TaskDescriptorId")]
        public Guid Id { get; set; }
        public string Name { get;set; }
        public string Description { get; set; }
        public bool IsBulk { get; set; }
    }
}