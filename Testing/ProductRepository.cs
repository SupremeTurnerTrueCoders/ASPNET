using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("Select * From products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE id = @id",
                new { id = id });
        }

       

        public void UpdateProduct(Product prod)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE id = @id",
                new { name = prod.Name, price = prod.Price, id = prod.Id });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, ImageLocation) VALUES(@name, @price, @imageLocation);",
                new { name = productToInsert.Name, price = productToInsert.Price, imageLocation = productToInsert.ImageLocation });
        }

       


        public void DeleteProduct(Product product)
        {
        

            _conn.Execute("DELETE FROM Products WHERE Id = @id",
               new { id = product.Id });
        }
    }
}
