using Cashback.Database.Context;
using Cashback.Domain.Entities;
using Cashback.Domain.Entities.BuyerAggregate;
using Cashback.Domain.Interfaces;
using Cashback.Infrastructure.ExternalServices.SpotifyService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Cashback.Service.Sync
{
    public static class SyncData
    {
        public static void Sync(IServiceProvider serviceProvider)
        {
            DiskEcommerceContext context = serviceProvider.GetRequiredService<DiskEcommerceContext>();
            SpotifyService spotifyService = (SpotifyService)serviceProvider.GetRequiredService<ISpotifyService>();

            List<Disk> disks = spotifyService.Get50AlbumsForEachGenre();

            foreach (var disk in disks)
            {
                context.Add(disk);
                context.SaveChanges();
            }

            context.Buyers.Add(new Buyer(Guid.Parse("6BF51D86-C0C2-4C91-988F-7CFE1A236587"), "Buyer Test 1"));
            context.Buyers.Add(new Buyer(Guid.Parse("29FEAC38-64E0-44CA-83FB-E9837AEAE110"), "Buyer Test 2"));
            context.SaveChanges();
        }        
    }
}
