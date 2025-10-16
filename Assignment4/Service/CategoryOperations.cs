using System.Collections.Generic;
using System.Linq;
using DataServiceLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLayer.Service
{
    public class CategoryOperations
    {
        public List<Category> GetCategories()
        {
            using var db = new NorthwindContext();
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            using var db = new NorthwindContext();
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category CreateCategory(string name, string description)
        {
            using var db = new NorthwindContext();

            // Calculate next ID
            var maxId = db.Categories.Any() ? db.Categories.Max(c => c.Id) : 0;
            var newId = maxId + 1;

            var category = new Category { Id = newId, Name = name, Description = description };
            db.Categories.Add(category);
            db.SaveChanges();

            return category;
        }

        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return false;
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return false;
            }
            category.Name = name;
            category.Description = description;
            db.SaveChanges();
            return true;
        }
    }
}
