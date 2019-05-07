using Cashback.Commom.Publisher;
using Cashback.Domain.Entities.OrderAggregate;

namespace Cashback.Domain.Events
{
    public class OrderPlacedEvent : Event
    {

        public OrderPlacedEvent(Order orderToPLace)
        {
            this.Order = orderToPLace;
        }

        public Order Order { get; set; }
    }
}
