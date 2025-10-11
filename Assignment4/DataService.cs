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

        public void Run()
        {
            var categories = GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }
            Console.WriteLine(categories.Count);
        }
    }
}