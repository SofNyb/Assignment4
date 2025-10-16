using DataServiceLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLayer.Service
{
    public class OrderOperations
    {
        public List<Order> GetOrders()
        {
            using var db = new NorthwindContext();
            var orders = db.Orders
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .ToList();

            return orders;
        }

        public Order GetOrder(int id)
        {
            using var db = new NorthwindContext();
            var order = db.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                .AsNoTracking()
                .FirstOrDefault(o => o.Id == id);
            return order;
        }
    }
}
