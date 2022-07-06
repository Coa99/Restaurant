using System.Collections.Generic;
using Restaurant.Model;

namespace Restaurant.Service
{
    public interface IOrderService
    {
        public Order GetById(int id);
        public IEnumerable<Order> GetAll();
        public Order Create(Order order);
        public Order Update(int id, Order order);
    }
}