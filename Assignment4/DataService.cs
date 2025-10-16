using DataServiceLayer.Models;
using DataServiceLayer.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductWithCategory = DataServiceLayer.Service.ProductOperations.ProductWithCategory;
using ProductWithName = DataServiceLayer.Service.ProductOperations.ProductWithName;


namespace DataServiceLayer
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

        public List<Product> GetProducts()
        {
            return _productOperations.GetProducts();
        }

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


        /* Orders */
        private readonly OrderOperations _orderOperations = new OrderOperations();

        public List<Order> GetOrders()
        {
            return _orderOperations.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return _orderOperations.GetOrder(id);
        }

        /* OrderDetails */

        private readonly OrderDetailOperations _orderDetailOperations = new OrderDetailOperations();

        public List<OrderDetails> GetOrderDetails()
        {
            return _orderDetailOperations.GetOrderDetailsByOrderId(0);
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            return _orderDetailOperations.GetOrderDetailsByOrderId(id);
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            return _orderDetailOperations.GetOrderDetailsByProductId(productId);
        }
    }
}