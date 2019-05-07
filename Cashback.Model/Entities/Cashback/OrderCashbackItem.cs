using Cashback.Commom.AggregateRoots;
using Cashback.Commom.Entities;
using Cashback.Domain.Entities.OrderAggregate;

namespace Cashback.Domain.Entities.CashbackAggregate
{
    public class OrderCashbackItem : BaseEntity, IAggregateRoot
    {
        protected OrderCashbackItem() {}

        public OrderCashbackItem(OrderItem relatedOrderItem, decimal cashbackPercentage)
        {
            RelatedOrderItem = relatedOrderItem;
            CashbackPercentage = cashbackPercentage;
            CashbackValue = ((RelatedOrderItem.UnitPrice * relatedOrderItem.Units) * CashbackPercentage) / 100 ;
        }

        public OrderItem RelatedOrderItem { get; private set; }
        public decimal CashbackPercentage { get; private set; }
        public decimal CashbackValue { get; private set; }

    }
}