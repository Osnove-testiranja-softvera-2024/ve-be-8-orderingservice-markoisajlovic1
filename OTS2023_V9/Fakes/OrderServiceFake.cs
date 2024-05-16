using OTS2023_V9.Models;
using OTS2023_V9.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Fakes
{
    

    public class OrderServiceFake : IOrderService
    {

        public double total;

        public Order GetOrderById(Guid id)
        {
            Order order = new Order();
            order.Id = id;
            order.Total = total;
            return order;
        }

        public List<Order> GetUserOrdersWithDeadlineBetween(Guid userId, DateTime monthBefore, DateTime now)
        {
            throw new NotImplementedException();
        }

        public void UpdateTotal(double difference)
        {
            total = difference;
        }
    }
}
