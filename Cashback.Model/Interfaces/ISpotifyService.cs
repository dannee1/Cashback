using System.Collections.Generic;
using Cashback.Domain.Entities;

namespace Cashback.Domain.Interfaces
{
    public interface ISpotifyService
    {
        List<Disk> Get50AlbumsForEachGenre();
    }
}