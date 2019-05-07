using Cashback.Domain.Entities.CashbackAggregate;
using System;
using System.Collections.Generic;

namespace Cashback.Domain.Interfaces
{
    public interface ICashBackRepository
    {
        void AddOrderCashBack(OrderCashback orderCashback);
        OrderCashback GetOrderCashBack(Guid orderID);
        
    }
}
