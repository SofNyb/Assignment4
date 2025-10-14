using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4;
using ProductWithCategory = Assignment4.ProductOperations.ProductWithCategory;
using ProductWithName = Assignment4.ProductOperations.ProductWithName;


namespace Assignment4
{
    public class DataService
    {
        /* Category */
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

        /* Products */
        private readonly ProductOperations _productOperations = new ProductOperations();

        public Product GetProduct(int id)
        {
            return _productOperations.GetProduct(id);
        }

        public List<ProductWithCategory> GetProductByCategory(int id)
        {
            return _productOperations.GetProductByCategory(id);
        }

        public List<ProductWithName> GetProductByName(string name)
        {
            return _productOperations.GetProductByName(name);
        }

    }
}