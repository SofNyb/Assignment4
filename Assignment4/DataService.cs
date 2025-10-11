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
        public static List<string> GetCategories()
        {
            using var db = new NorthwindContext();
            return [.. db.Categories.Select(c => c.Name)];
        }

        public void Run()
        {
            var categories = GetCategories();
            foreach (var name in categories)
            {
                Console.WriteLine(name);
            }
        }
    }
}