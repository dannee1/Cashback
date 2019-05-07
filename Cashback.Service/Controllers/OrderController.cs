using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback.Commom.Notifications;
using Cashback.Commom.Pagging;
using Cashback.Commom.Publisher;
using Cashback.Domain.Commands;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.OrderAggregate;
using Cashback.Domain.Interfaces;
using Cashback.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.Service.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : APIController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublisher _publisher;

        public OrderController(IOrderRepository orderRepository,
                               IPublisher publisher, 
                               IUnitOfWork unitOfWork,
                               DomainNotificationHandler domainNotificationHandler): base(domainNotificationHandler, unitOfWork)
        {
            _orderRepository = orderRepository;
            _publisher = publisher;
            
        }

        /// <summary>
        /// Obter pedido pelo ID 
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Pedido</returns>
        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {

            // TODO: Mapear para DTO
            var order = _orderRepository.Get(id);


            if (order == null)
                return NotFound();

            return Ok(_orderRepository.Get(id));
        }

        /// <summary>
        /// Obter lista de pedidos
        /// </summary>
        /// <param name="begin">Data de Inicio</param>
        /// <param name="finalDate">Data de fim</param>
        /// <param name="actualPage">Página atual</param>
        /// <param name="pageSize">Itens por página</param>
        /// <returns>Lista paginada de pedido</returns>
        [HttpGet()]
        public ActionResult<PagedResult<Order>> GetPaged(DateTime begin, DateTime finalDate, int actualPage = 1, int pageSize = 10)
        {
            // TODO: Mapear para DTO
            return Ok(_orderRepository.GetPagged(actualPage, pageSize, begin, finalDate));
        }

        /// <summary>
        /// Efetuar uma pedido
        /// </summary>
        /// <param name="basketViewModel">Dados do pedido</param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult PlaceOrder(BasketViewModel basketViewModel)
        {
            var items = new Dictionary<Guid, int>();
            basketViewModel.BasketItems.ForEach(i => items.Add(i.DiskId, i.Units));

           var placeOrderCommand = new PlaceOrderCommand(basketViewModel.BuyerId, items);

            _publisher.SendCommand<PlaceOrderCommand>(placeOrderCommand);

            return Response(placeOrderCommand);
            
        }
    }
}
