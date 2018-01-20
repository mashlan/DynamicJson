using System;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Product : IAssetTrackEntity
    {
        [JsonProperty("ProductID")]
        public Guid Id { get; set; }

        [JsonProperty("Active")]
        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PartControlNumber { get;set; }

        [JsonProperty("ManufacturerID")]
        public Guid ManufacturerId {get; set; }

        public DateTime DateModified { get; set; }
    }
}