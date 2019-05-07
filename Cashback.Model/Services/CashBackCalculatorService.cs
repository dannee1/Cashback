using Cashback.Domain.Entities.CashbackAggregate;
using Cashback.Domain.Entities.OrderAggregate;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Interfaces;
using System;

namespace Cashback.Domain.Services
{
    public class CashBackCalculatorService : ICashBackCalculatorService
    {
        private readonly ICashBackConfigurationService _cashBackConfigurationService;

        public CashBackCalculatorService(ICashBackConfigurationService cashBackConfigurationService)
        {
            _cashBackConfigurationService = cashBackConfigurationService;
        }

        public OrderCashback CalculateOrderCashBack(Order order)
        {
            OrderCashback orderCashBack = new OrderCashback(order);

            foreach (var orderItem in order.OrderItems)
            {
                var cashbackPercentage = GetCashbackPercentage(order.OrderDate, orderItem.OrderedDisk.Genre);
                orderCashBack.AddCashbackOrderItem(new OrderCashbackItem(orderItem, cashbackPercentage));
            }
           
            return orderCashBack;
        }

        private decimal GetCashbackPercentage(DateTime orderDate, DiskGenreEnum genre)
        {
            return _cashBackConfigurationService.GetPercentage(genre, orderDate);
        }
    }
}
