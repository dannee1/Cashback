using Cashback.Domain.Entities.CashbackAggregate;
using Cashback.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cashback.Domain.Events
{
    public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
    {

        private readonly ICashBackRepository _cashBackRepository;
        private readonly ICashBackCalculatorService _cashBackCalculatorService;

        public OrderPlacedEventHandler(ICashBackCalculatorService cashBackCalculatorService, ICashBackRepository cashBackRepository)
        {
            _cashBackCalculatorService = cashBackCalculatorService;
            _cashBackRepository = cashBackRepository;
        }


        Task INotificationHandler<OrderPlacedEvent>.Handle(OrderPlacedEvent orderPlacedEvent, CancellationToken cancellationToken)
        {
            OrderCashback orderCashback = _cashBackCalculatorService.CalculateOrderCashBack(orderPlacedEvent.Order);
            _cashBackRepository.AddOrderCashBack(orderCashback);

            return Unit.Task;
        }
    }
}
