using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Location : IAssetTrackEntity
    {
        [JsonProperty("LocationID")]
        public Guid Id { get; set; }

        [JsonProperty("ParentLocationID")]
        public Guid ParentLocationId { get; set; }

        [JsonProperty("Name")]
        public string Names { get; set; }

        [JsonProperty("Code")]
        public string Codes { get; set; }
    }
}