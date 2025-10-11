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
        public void PrintCategoryNames()
        {
            using var db = new NorthwindContext();
            foreach (var category in db.Categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void Run()
        {
            PrintCategoryNames();
            // You can add more code to run other methods if needed
        }
    }
}