using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer
{
    public class OrderDetailOperations
    {
        public List<OrderDetails> GetOrderDetails()
        {
            using var db = new NorthwindContext();
            return db.OrderDetails
                .Include(od => od.Product)
                .AsNoTracking()
                .ToList();
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using var db = new NorthwindContext();
            return db.OrderDetails
                .Where(od => od.OrderId == id)
                .Include(od => od.Product)
                .AsNoTracking()
                .ToList();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            using var db = new NorthwindContext();
            return db.OrderDetails
                .Where(od => od.ProductId == productId)
                .Include(od => od.Order)
                .AsNoTracking()
                .ToList();
        }
    }
}
