using Cashback.Database.Context;
using Cashback.Domain.Interfaces;

namespace Cashback.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CashbackContext _context;

        public UnitOfWork(CashbackContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
