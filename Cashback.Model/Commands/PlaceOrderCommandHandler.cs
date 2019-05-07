using Cashback.Commom.Notifications;
using Cashback.Commom.Publisher;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.BuyerAggregate;
using Cashback.Domain.Entities.OrderAggregate;
using Cashback.Domain.Events;
using Cashback.Domain.Factories;
using Cashback.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cashback.Domain.Commands
{

    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Unit>
    {
        private readonly IBuyerRepository _buyerRepository;
        private readonly IDiskReadRepositoy _diskReadOnlyRepositoy;
        private readonly IOrderRepository _orderRepository;
        private readonly IPublisher _publisher;
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public PlaceOrderCommandHandler(IBuyerRepository buyerRepository, IDiskReadRepositoy diskReadOnlyRepositoy, IOrderRepository orderRepository, IPublisher publisher, DomainNotificationHandler domainNotificationHandler)
        {
            _buyerRepository = buyerRepository;
            _diskReadOnlyRepositoy = diskReadOnlyRepositoy;
            _orderRepository = orderRepository;
            _publisher = publisher;
            _domainNotificationHandler = domainNotificationHandler;
        }

        public Task<Unit> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {

            if (!command.IsValid())
            {
                command.ValidationResult.Errors.ToList().ForEach(error => _domainNotificationHandler.Handle(new DomainNotification(command.GetType().ToString(), error.ErrorMessage)));
                return Unit.Task;
            }

            Buyer buyer = _buyerRepository.GetBuyer(command.BuyerId);

            List<BasketItem> basketItems = new List<BasketItem>();

            command.basketItems.ToList().ForEach(item => basketItems.Add(new BasketItem(_diskReadOnlyRepositoy.Get(item.Key),item.Value)));

            Order orderToPLace = OrderFactory.Create(buyer, basketItems);

            _orderRepository.PlaceOrder(orderToPLace);

            _publisher.RaiseEvent(new OrderPlacedEvent(orderToPLace));

            return Unit.Task;
        }
    }
}
