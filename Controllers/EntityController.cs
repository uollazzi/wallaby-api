using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wallaby_api.Services;
using wallaby_api.Models;
using MongoDB.Bson;

namespace wallaby_api.Controllers
{
    public class EntityController : Controller
    {
        private readonly IEntityStore _entityStore;
        public EntityController(IEntityStore entityStore)
        {
            _entityStore = entityStore;
        }

        [HttpPost("test")]
        public void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                var p = new Post();
                p.Slug = "post" + (i + 1).ToString();
                p.Title = "Titolo post " + (i + 1).ToString();
                p.Text = "Testo post " + (i + 1).ToString();

                _entityStore.AddEntity(p);
            }

            for (int i = 0; i < 5; i++)
            {
                var p = new Product();
                p.Slug = "prodotto" + (i + 1).ToString();
                p.ProductId = (i + 1).ToString();
                p.Title = "Titolo prodotto " + (i + 1).ToString();

                _entityStore.AddEntity(p);
            }

        }

        [HttpGet("posts")]
        public IEnumerable<Post> GetPosts()
        {
            return _entityStore.GetEntities<Post>("", 100, 1);
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _entityStore.GetEntities<Product>("", 100, 1);
        }

        // GET api/values
        [HttpGet("{type}/{orderBy}/{pageSize}/{pageNumber}")]
        public IEnumerable<Entity> Get(string type, string orderBy, int pageSize, int pageNumber)
        {
            return _entityStore.GetEntities<Entity>(orderBy, pageSize, pageNumber);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Entity Get(ObjectId id)
        {
            return _entityStore.GetEntity(id);
        }

        // POST api/values
        [HttpPost]
        public bool Post(Entity entity)
        {
            return _entityStore.AddEntity(entity);
        }

        // PUT api/values/5
        [HttpPut("{type}/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{type}/{id}")]
        public void Delete(int id)
        {
        }
    }
}
