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

        public void Run()
        {
            var categories = GetCategories();
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine(categories.Count);

            var category = GetCategory(2);
            if (category != null)
            {
                Console.WriteLine(category.Name);
            }
        }
    }
}