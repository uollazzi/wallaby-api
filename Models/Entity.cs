using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace wallaby_api.Models
{
    [BsonDiscriminator(RootClass = true)]
    public abstract class Entity
    {
        [BsonRepresentation(BsonType.ObjectId)] //serve per farlo vedere come stringa quando viene jsonserialized anche se è un ObjectId a tutti gli effetti
        public string Id { get; set; }

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
        public bool Online { get; set; }

        [BsonIgnore]
        public bool IsDeleted
        {
            get
            {
                return DeletedAt.HasValue;
            }
        }
    }
}