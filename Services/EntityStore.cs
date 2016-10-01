using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using wallaby_api.Models;
using MongoDB.Bson.Serialization.Conventions;

namespace wallaby_api.Services
{
    public class EntityStore : IEntityStore
    {
        MongoClient _client;
        IMongoDatabase _db;

        public EntityStore()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("wallaby");

            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("camelCase", pack, t => true);
        }

        public IEnumerable<Entity> GetEntities<Entity>(string orderBy, int pageSize, int pageNumber)
        {
            return _db.GetCollection<Entity>("entities")
                      .OfType<Entity>()
                      .AsQueryable()
                      .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public Entity GetEntity(string id)
        {
            return _db.GetCollection<Entity>("entities").AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public bool AddEntity(Entity entity)
        {
            try
            {
                _db.GetCollection<Entity>("entities").InsertOne(entity);

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }
    }
}
