using System.Collections.Generic;
using MongoDB.Bson;
using wallaby_api.Models;

namespace wallaby_api.Services
{
    public interface IEntityStore
    {
        IEnumerable<T> GetEntities<T>(string orderBy, int pageSize, int pageNumber);
        
        Entity GetEntity(ObjectId id);

        bool AddEntity(Entity entity);
    }
}
