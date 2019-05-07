using Cashback.Domain.Entities.CashbackAggregate;
using Cashback.Domain.Entities.OrderAggregate;

namespace Cashback.Domain.Interfaces
{
    public interface ICashBackCalculatorService
    {
        OrderCashback CalculateOrderCashBack(Order order);
    }
}