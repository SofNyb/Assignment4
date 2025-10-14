using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4;

namespace Assignment4
{
    public class DataService
    {
        private readonly CategoryOperations _categoryOperations = new CategoryOperations();

        public List<Category> GetCategories()
        {
            return _categoryOperations.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return _categoryOperations.GetCategory(id);
        }

        public Category CreateCategory(string name, string description)
        {
            return _categoryOperations.CreateCategory(name, description);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryOperations.DeleteCategory(id);
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            return _categoryOperations.UpdateCategory(id, name, description);
        }

        public Product GetProduct(int id)
        {
            using var db = new NorthwindContext();
            return db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public class ProductWithCategory
        {
            public string Name { get; set; }
            public string CategoryName { get; set; }
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

        public class ProductWithName
        {
            public string ProductName { get; set; }  
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