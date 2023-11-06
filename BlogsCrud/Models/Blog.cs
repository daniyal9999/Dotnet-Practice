using System.Numerics;

namespace BlogsCrud.Models
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int likes { get; set; } 

    }
}
