using System;
using System.Collections.Generic;
using System.Linq;
using Cashback.Commom.Pagging;
using Cashback.Database.Context;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.OrderAggregate;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cashback.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CashbackContext _context;

        public OrderRepository(CashbackContext context)
        {
            _context = context;
        }

        public Order Get(Guid id)
        {
            return _context.Orders
                           .Include(x => x.OrderItems)
                           .Include(x => x.Buyer)
                           .Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
       

        public PagedResult<Order> GetPagged(int actualPage, int pageSize, DateTime begin, DateTime end)
        {
            return _context.Orders
                  .Include(x => x.OrderItems)
                  .Include(x => x.Buyer).Where(o=>o.OrderDate>= begin && o.OrderDate<= end)
                  .GetPaged(actualPage, pageSize);
            
        }

        public void PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
