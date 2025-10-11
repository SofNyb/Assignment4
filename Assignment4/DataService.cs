using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4;

var db = new NorthwindContext();


namespace Assignment4
{
    public class DataService
    {
        public class Categories
        {
            public static List<Category> GetCategories()
            {
                using var db = new NorthwindContext();
                return [.. db.Categories];
            }

            public static void Run()
            {
                using var db = new NorthwindContext();
                foreach (var category in db.Categories)
                {
                    Console.WriteLine(category.Name);
                }
            }

        }
    }
}