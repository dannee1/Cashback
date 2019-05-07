using Cashback.Commom.Pagging;
using Cashback.Domain.Entities.BuyerAggregate;
using System;

namespace Cashback.Domain.Interfaces
{
    public interface IBuyerRepository
    {
        Buyer GetBuyer(Guid id);
        PagedResult<Buyer> GetPagged(int actualPage, int pageSize);
    }
}
