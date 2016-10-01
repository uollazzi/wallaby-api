using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace wallaby_api.Models
{
    [BsonDiscriminator(RootClass = true)]
    public abstract class Entity
    {
        private DateTime _now = DateTime.UtcNow;

        public MongoDB.Bson.ObjectId Id { get; set; }

        private DateTime? _CreatedAt;

        [Required]
        public DateTime CreatedAt
        {
            get
            {
                return this._CreatedAt.HasValue ? this._CreatedAt.Value : DateTime.UtcNow;
            }
            set
            {
                this._CreatedAt = value;
            }
        }
        public DateTime? DeletedAt { get; set; }

        [Required]
        public string Slug { get; set; }
    }
}