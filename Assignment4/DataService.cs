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

            // id
            var maxId = db.Categories.Any() ? db.Categories.Max(c => c.Id) : 0;


            var category = new Category { Id = maxId + 1, Name = name, Description = description };
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

        public void Run()
        {
            var categories = GetCategories();
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine(categories.Count);

            var category = GetCategory(1);
            if (category != null)
            {
                Console.WriteLine(category.Name);
                return;
            }

            category = CreateCategory("Test", "This is a test category");

        }
    }
}