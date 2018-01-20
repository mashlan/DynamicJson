﻿using System;

namespace Mashlan.DynamicJson.Domain.Entities
{
    public class Context : IAssetTrackEntity
    {
        public Guid Id { get; set; }
        public string Application { get;set; }
        public Task Task { get; set; }
        public DateTime DateCollected { get; set; }
        public User CollectingUser { get;set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get;set; }
    }
}