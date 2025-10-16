using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class ProductOperations
    {
        public class ProductWithCategory
        {
            public string Name { get; set; }
            public string CategoryName { get; set; }
        }

        public class ProductWithName
        {
            public string ProductName { get; set; }
        }

        public Product GetProduct(int id)
        {
            using var db = new NorthwindContext();
            return db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public List<ProductWithCategory> GetProductByCategory(int id)
        {
            using var db = new NorthwindContext();
            var products = db.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == id)
                .AsNoTracking()
                .ToList();

            return products
                .Select(p => new ProductWithCategory
                {
                    Name = p.Name,
                    CategoryName = p.Category?.Name
                })
                .ToList();
        }

        public List<ProductWithName> GetProductByName(string name)
        {
            using var db = new NorthwindContext();
            var products = db.Products
                .Where(p => EF.Functions.ILike(p.Name, $"%{name}%"))
                .AsNoTracking()
                .ToList();

            return products
                .Select(p => new ProductWithName
                {
                    ProductName = p.Name
                })
                .ToList();
        }

    }
}
