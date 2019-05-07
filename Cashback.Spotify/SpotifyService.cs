using Cashback.Domain.Entities;
using Cashback.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using Cashback.Domain.Enumerators;

namespace Cashback.Infrastructure.ExternalServices.SpotifyService
{
    public class SpotifyService : ISpotifyService
    {
        private readonly Random _random;

        public SpotifyService()
        {
            _random = new Random();
        }

        public List<Disk> Get50AlbumsForEachGenre()
        {
            CredentialsAuth auth = new CredentialsAuth(SpotifyServiceConfig.CLIENTID , SpotifyServiceConfig.SECRET);
            Token token = auth.GetToken().Result;
            SpotifyWebAPI api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };

            var genres = Enum.GetValues(typeof(DiskGenreEnum));

            List<Disk> disks = new List<Disk>();

            foreach (var genre in genres)
            {
                SearchItem search = api.SearchItems(genre.ToString(), SearchType.Album, 50);

                foreach (var spotifyDisk in search.Albums.Items)
                {
                    disks.Add(new Disk(spotifyDisk.Name, GetDescription(spotifyDisk), GetRandomPrice(), (DiskGenreEnum) genre));
                }
            }

            return disks;
        }

        private string GetDescription(SimpleAlbum sDisk)
        {
            return $"Released Date: {sDisk.ReleaseDate} | URI: {sDisk.Uri} | Album Type: {sDisk.AlbumType}";
        }

        private decimal GetRandomPrice()
        {
            return Convert.ToDecimal(string.Format("{0:0.##}", _random.NextDouble() * 10));
        }
    }
}
