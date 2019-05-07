using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
