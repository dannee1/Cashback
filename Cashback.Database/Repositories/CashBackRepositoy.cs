﻿using Cashback.Database.Context;
using Cashback.Domain.Entities.CashbackAggregate;
using Cashback.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cashback.Database.Repositories
{
    public class CashBackRepository : ICashBackRepository
    {
        private readonly DiskEcommerceContext _context;

        public CashBackRepository(DiskEcommerceContext context)
        {
            _context = context;
        }

        public OrderCashback GetOrderCashBack(Guid orderID)
        {
            return _context.Cashbacks
            .Include(x => x.OrderCashbacktems)
            .Include(x => x.RelatedOrder)
            .Include(x => x.RelatedOrder.OrderItems)
            .Where(x => x.RelatedOrder.Id == orderID).FirstOrDefault();
        }

        public void AddOrderCashBack(OrderCashback orderCashback)
        {
            _context.Cashbacks.Add(orderCashback);
        }
    }
}
