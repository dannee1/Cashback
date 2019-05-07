using System;
using System.Collections.Generic;
using System.Linq;
using Cashback.Commom.Pagging;
using Cashback.Database.Context;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.BuyerAggregate;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Interfaces;

namespace Cashback.Database.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly DiskEcommerceContext _context;

        public BuyerRepository(DiskEcommerceContext context)
        {
            _context = context;
        }

        public Buyer GetBuyer(Guid id)
        {
            return _context.Buyers.Find(id);
        }

        public PagedResult<Buyer> GetPagged(int actualPage, int pageSize)
        {
            return _context.Buyers.GetPaged(actualPage, pageSize);

        }
    }
}