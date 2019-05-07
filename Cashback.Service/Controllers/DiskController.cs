using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback.Commom.Pagging;
using Cashback.Domain.Entities;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Interfaces;
using Cashback.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cashback.Service.Controllers
{
    [Route("api/disks")]
    [ApiController]
    public class DiskController : ControllerBase
    {
        private readonly IDiskReadRepositoy _diskReadOnlyRepositoy;

        public DiskController(IDiskReadRepositoy diskReadOnlyRepositoy)
        {
            _diskReadOnlyRepositoy = diskReadOnlyRepositoy;
        }

        /// <summary>
        /// Obter disco pelo gênero
        /// </summary>
        /// <param name="genre">Gênero</param>
        /// <param name="actualPage">Pagina atual</param>
        /// <param name="pageSize">Itens por pagina</param>
        /// <returns>Discos</returns>
        [HttpGet()]
        public ActionResult<PagedResult<Disk>> GetByGenre(DiskGenreEnum genre,int actualPage = 1, int pageSize = 10)
        {
            // TODO: Mapear para DTO
            return Ok(_diskReadOnlyRepositoy.GetPagged(actualPage, pageSize, genre));
        }

        /// <summary>
        /// Obter disco pelo ID
        /// </summary>
        /// <param name="id">ID do disco</param>
        /// <returns>Disco</returns>
        [HttpGet("{id}")]
        public ActionResult<Disk> GetDiskById(Guid id)
        {
            // TODO: Mapear para DTO
            Disk disk = _diskReadOnlyRepositoy.Get(id);

            if (disk == null)
                return NotFound();

            return Ok(disk);
        }

        
    }
}
