using Cashback.Commom.Pagging;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.BuyerAggregate;
using Cashback.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.Service.Controllers
{
    [Route("api/buyer")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerController(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        /// <summary>
        /// Retorna uma lista de clientes
        /// </summary>
        /// <param name="actualPage">pagina atual</param>
        /// <param name="pageSize">itens por página</param>
        /// <returns>Lista paginada de clientes</returns>
        [HttpGet()]
        public ActionResult<PagedResult<Buyer>> Get(int actualPage = 1, int pageSize = 20)
        {
            // TODO: Mapear para DTO
            return Ok(_buyerRepository.GetPagged(actualPage, pageSize));
        }

    }
}
