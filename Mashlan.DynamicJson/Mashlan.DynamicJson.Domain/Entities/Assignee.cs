using System;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Assignee : IAssetTrackEntity
    {
        [JsonProperty("AssigneeID")]
        public Guid Id { get; set; }

        [JsonProperty("Active")]
        public bool IsActive { get; set; }

        public string FirstName { get;set; }

        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public string EmailAddress { get; set; }

        [JsonProperty("LocationID")]
        public Location Location{get; set; }

        public string Code { get; set; }
    }
}