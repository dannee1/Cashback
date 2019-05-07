using System;
using Cashback.Domain.Enumerators;

namespace Cashback.Domain.Interfaces
{
    public interface ICashBackConfigurationService
    {
        decimal GetPercentage(DiskGenreEnum genre, DateTime date);
    }
}