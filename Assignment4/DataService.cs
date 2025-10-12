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

        public List<Category> GetCategory()
        {
            using var db = new NorthwindContext();
            return db.Category.ToList();
        }

        public void Run()
        {
            var categories = GetCategories();
            foreach (var c in categories)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine(categories.Count);

            var category = GetCategory();
            foreach (var cat in category)
            {
                Console.WriteLine(cat.Name);
            }
            Console.WriteLine(cat.Count);
        }
    }
}