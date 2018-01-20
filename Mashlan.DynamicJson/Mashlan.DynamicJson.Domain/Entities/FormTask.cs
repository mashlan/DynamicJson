using System;
using System.Collections.Generic;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class FormTask : IAssetTrackEntity
    {
        public Guid Id { get; set; }

        public bool UseAt4Queue { get; set; }

        public string CollectionEntity { get; set; }

        public ICollection<Page> Pages { get; set; }
    }
}
