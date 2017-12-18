﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Services.Normal.Contracts;
using TicketSystem.Services.Normal.Models.Users;

namespace TicketSystem.Services.Normal.Implementation
{
    public class UserService : IUserService
    {
        private readonly TicketSystemDbContext db;

        public UserService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< IEnumerable< SearchAlbumsServiceModel > > SearchAlbumsAsync( string searchTerm )
        {
            if ( string.IsNullOrEmpty( searchTerm ) )
            {
                return null;
            }

            var albums = await this.db
                .Albums
                .Where( a => a.Name.Contains( searchTerm ) )
                .ProjectTo< SearchAlbumsServiceModel >()
                .ToListAsync();

            return albums;
        }

        public async Task< IEnumerable< SearchBandsServiceModel > > SearchBandsAsync( string searchTerm )
        {
            if ( string.IsNullOrEmpty( searchTerm ) )
            {
                return null;
            }

            var bands = await this.db
                .Bands
                .Where( a => a.Name.Contains( searchTerm ) )
                .ProjectTo< SearchBandsServiceModel >()
                .ToListAsync();

            return bands;
        }

        public async Task< IEnumerable< SearchSongsServiceModel > > SearchSongsAsync( string searchTerm )
        {
            if ( string.IsNullOrEmpty( searchTerm ) )
            {
                return null;
            }

            var songs = await this.db
                .Songs
                .Where( a => a.Name.Contains( searchTerm ) )
                .ProjectTo< SearchSongsServiceModel >()
                .ToListAsync();

            return songs;
        }

        public async Task< IEnumerable< SearchConcertsServiceModel > > SearchConcertsAsync( string searchTerm )
        {
            if ( string.IsNullOrEmpty( searchTerm ) )
            {
                return null;
            }

            var concerts = await this.db
                .Concerts
                .Where( a => a.Name.Contains( searchTerm ) )
                .ProjectTo< SearchConcertsServiceModel >()
                .ToListAsync();

            return concerts;
        }

        public async Task< SearchEverywhereServiceModel > SearchEverywhereAsync( string searchTerm )
        {
            var result = new SearchEverywhereServiceModel();

            var songs = await this.SearchSongsAsync( searchTerm );
            var albums = await this.SearchAlbumsAsync( searchTerm );
            var bands = await this.SearchBandsAsync( searchTerm );
            var concerts = await this.SearchConcertsAsync( searchTerm );

            if ( songs != null && songs.Any() )
            {
                result.Songs = songs;
            }
            if ( albums != null && albums.Any() )
            {
                result.Albums = albums;
            }
            if ( bands != null && bands.Any() )
            {
                result.Bands = bands;
            }
            if ( concerts != null && concerts.Any() )
            {
                result.Concerts = concerts;
            }

            return result;
        }
    }
}