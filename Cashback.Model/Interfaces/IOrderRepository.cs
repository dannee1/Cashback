using Cashback.Commom.Pagging;
using Cashback.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Interfaces
{
    public interface IOrderRepository
    {
        PagedResult<Order> GetPagged(int actualPage, int pageSize, DateTime begin, DateTime end);
        Order Get(Guid id);
        void PlaceOrder(Order order);
    }
}
