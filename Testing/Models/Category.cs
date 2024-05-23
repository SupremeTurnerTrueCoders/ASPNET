using System.Collections.Generic;

namespace Testing.Models
{
    public class Category
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public int CategoryID { get; set; }

        public string OnSale{ get; set; }

        public int StockLevel {  get; set; }

        public IEnumerable<Category> Categories { get; set;}


    }
}
