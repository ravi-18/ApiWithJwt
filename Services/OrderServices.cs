using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithJwt.Interface;
using ApiWithJwt.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWithJwt.Services
{
    public class OrderServices : IOrderServices
    {
        readonly DatabaseContext _dbContext = new();

        public OrderServices(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderModel> GetListOrder()
        {
            try
            {
                return _dbContext.Orders.ToList();
            }
            catch
            {
                throw;
            }
        }

        public OrderModel GetOrderDetails(int id)
        {
            try
            {
                OrderModel? order = _dbContext.Orders.Find(id);
                if (order != null)
                {
                    return order;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddOrder(OrderModel order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOrder(OrderModel order)
        {
            try
            {
                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public OrderModel DeleteOrder(int id)
        {
            try
            {
                OrderModel? order = _dbContext.Orders.Find(id);

                if (order != null)
                {
                    _dbContext.Orders.Remove(order);
                    _dbContext.SaveChanges();
                    return order;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckOrder(int id)
        {
            return _dbContext.Orders.Any(e => e.OrderId == id);
        }
    }
}