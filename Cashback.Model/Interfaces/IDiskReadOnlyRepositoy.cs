using Cashback.Commom.Pagging;
using Cashback.Domain.Entities;
using Cashback.Domain.Enumerators;
using System;
using System.Collections.Generic;

namespace Cashback.Domain.Interfaces
{
    public interface IDiskReadRepositoy
    {
        Disk Get(Guid id);
        PagedResult<Disk> GetPagged(int actualPage, int pageSize, DiskGenreEnum genre);
    }
}
