using System;

namespace wallaby_api.Models
{
    public class Product : Entity, IRoutable
    {
        public string ProductId { get; set; }

        public LocalizedField Title { get; set; }

        public LocalizedField Slug { get; set; }
    }
}
