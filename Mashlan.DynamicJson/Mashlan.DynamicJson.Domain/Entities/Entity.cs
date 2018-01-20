using System;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Entity : IAssetTrackEntity
    {
        [JsonProperty("__Q_Id")]
        public Guid Id { get; set; }

        [JsonProperty("__Q_CollectionContextId")]
        public Guid CollectionContextId { get; set; }

        [JsonProperty("__Q_Created")]
        public DateTime Created { get; set; }

        [JsonProperty("__Q_Updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("@EntityValues")]
        public string EntityValues { get; set; }

        [JsonProperty("AssetID")]
        public Guid AssetId { get;set; }

        [JsonProperty("Active")]
        public bool IsActive { get; set; }

        public string AssetTag { get; set; }

        [JsonProperty("AssigneeID")]
        public Assignee Assignee { get; set; }

        [JsonProperty("ProductID")]
        public Product Product { get; set; }

        [JsonProperty("LocationID")]
        public Location Location { get;set; }

        public string SerialNumber { get;set; }

        public string Status { get; set; }

        public string MacAddress { get;set; }

        public string PONumber { get; set; }
    }
}