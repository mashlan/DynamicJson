using System;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class User : IAssetTrackEntity
    {
        [JsonProperty("UserID")]
        public Guid Id { get; set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public string MiddleInitial { get; set; }
    }
}