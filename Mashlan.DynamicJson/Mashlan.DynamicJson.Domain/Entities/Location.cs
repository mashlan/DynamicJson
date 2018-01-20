using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Location : IAssetTrackEntity
    {
        public Guid Id { get; set; }

        [JsonProperty("LocationID")]
        [NotMapped]
        public ICollection<string> LocationsGuids { get; set; }

        [JsonProperty("ParentLocationID")]
        [NotMapped]
        public ICollection<string> ParentLocationGuids { get; set; }

        [JsonProperty("Name")]
        [NotMapped]
        public ICollection<string> Names { get; set; }

        [JsonProperty("Code")]
        [NotMapped]
        public ICollection<string> Codes { get; set; }
    }

}