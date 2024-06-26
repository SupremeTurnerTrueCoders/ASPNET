using System.Collections.Generic;

namespace Testing.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageLocation { get; set; }
        public IEnumerable<Category> Categories { get; set;}
    }
}
