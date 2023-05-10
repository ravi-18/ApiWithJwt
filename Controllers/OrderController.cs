using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiWithJwt.Interface;
using ApiWithJwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiWithJwt.Controllers
{
    [Authorize]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _IOrder;

        public OrderController(IOrderServices IOrder)
        {
            _IOrder = IOrder;
        }

        // GET: api/order>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            return await Task.FromResult(_IOrder.GetListOrder());
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> Get(int id)
        {
            var order = await Task.FromResult(_IOrder.GetOrderDetails(id));
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // POST api/order
        [HttpPost]
        public async Task<ActionResult<OrderModel>> Post(OrderModel order)
        {
            _IOrder.AddOrder(order);
            return await Task.FromResult(order);
        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> Put(int id, OrderModel order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            try
            {
                _IOrder.UpdateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(order);
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> Delete(int id)
        {
            var order = _IOrder.DeleteOrder(id);
            return await Task.FromResult(order);
        }

        private bool OrderExists(int id)
        {
            return _IOrder.CheckOrder(id);
        }
    
    }
}