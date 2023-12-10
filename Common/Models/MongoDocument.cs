using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public abstract class MongoDocument
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime LastChangedAt { get; set; }
    }
}
