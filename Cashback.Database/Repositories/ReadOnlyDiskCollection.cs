using System;
using System.Collections.Generic;
using System.Linq;
using Cashback.Commom.Pagging;
using Cashback.Database.Context;
using Cashback.Domain.Entities;
using Cashback.Domain.Enumerators;
using Cashback.Domain.Interfaces;

namespace Cashback.Database.Repositories
{
    public class ReadOnlyDiskCollection : IDiskReadRepositoy
    {
        private readonly DiskEcommerceContext _context;

        public ReadOnlyDiskCollection(DiskEcommerceContext context)
        {
            _context = context;
        }

         public PagedResult<Disk> GetPagged(int actualPage, int pageSize, DiskGenreEnum genre)
        {
            return _context.Disks
                  .Where(d=>d.Genre == genre)
                  .OrderBy(d=>d.Name)
                  .GetPaged(actualPage, pageSize);

        }

        public Disk Get(Guid id)
        {
            return _context.Disks.Find(id);
        }
    }
}
