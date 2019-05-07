using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback.Commom.Notifications;
using Cashback.Commom.Pagging;
using Cashback.Commom.Publisher;
using Cashback.Domain.Commands;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.CashbackAggregate;
using Cashback.Domain.Entities.OrderAggregate;
using Cashback.Domain.Interfaces;
using Cashback.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.Service.Controllers
{
    
    [ApiController]
    public class CashbackController : ControllerBase
    {
        private readonly ICashBackRepository _cashBackRepository;

        public CashbackController(ICashBackRepository cashBackRepository)
        {
            _cashBackRepository = cashBackRepository;
        }

        /// <summary>
        /// Retorna o cashback de uma determinada venda
        /// </summary>
        /// <param name="orderID">ID da venda</param>
        /// <returns>objeto de cashback</returns>
        [HttpGet("api/orders/{orderID}/cashback")]
        public ActionResult<OrderCashback> Get(Guid orderID)
        {
            // TODO: DTO
            var cashBack = _cashBackRepository.GetOrderCashBack(orderID);

            if (cashBack == null)
                return NotFound();

            return Ok(cashBack);
        }
    
    }
}
