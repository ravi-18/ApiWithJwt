using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithJwt.Models;

namespace ApiWithJwt.Interface
{
    public interface IOrderServices
    {
        public List<OrderModel> GetListOrder();
        public OrderModel GetOrderDetails(int id);
        public void AddOrder(OrderModel order);
        public void UpdateOrder(OrderModel order);
        public OrderModel DeleteOrder(int id);
        public bool CheckOrder(int id);
    }
}