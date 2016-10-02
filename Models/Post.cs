namespace wallaby_api.Models
{
    public class Post : Entity, IRoutable
    {
        public LocalizedField Title { get; set; }
        public LocalizedField Text { get; set; }
        public LocalizedField Slug { get; set; }
    }
}
