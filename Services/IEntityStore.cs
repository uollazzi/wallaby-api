using System.Collections.Generic;
using wallaby_api.Models;

namespace wallaby_api.Services
{
    public interface IEntityStore
    {
        IEnumerable<Entity> GetEntities<Entity>(string orderBy, int pageSize, int pageNumber);
        
        Entity GetEntity(string id);

        bool AddEntity(Entity entity);
    }
}
