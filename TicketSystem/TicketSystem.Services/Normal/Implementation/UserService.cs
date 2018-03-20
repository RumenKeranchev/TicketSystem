using System;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Data;
using TicketSystem.Data.Models;
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

        public async Task< bool > BookTicketAsync( BookTicketServiceModel serviceModel )
        {
            if ( serviceModel == null )
            {
                return false;
            }

            var ticket = new Ticket
            {
                ConcertId = serviceModel.ConcertId,
                Count = serviceModel.Count,
                TicketPrice = serviceModel.TicketPrice,
                UserId = serviceModel.UserId
            };

            this.db.Tickets.Add( ticket );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task< IEnumerable< ListAllTicketsServiceModel > > CartAsync( string userId )
        {
            if ( string.IsNullOrEmpty( userId ) )
            {
                return null;
            }

            var tickets = await this.db
                .Tickets
                .Where( t => t.UserId == userId )
                .ProjectTo< ListAllTicketsServiceModel >()
                .ToListAsync();

            return tickets;
        }

        public async Task< bool > PostCommentAsync( CommentOnConcertServiceModel model )
        {
            if ( model == null )
            {
                return false;
            }

            var comment = new Comment
            {
                UserId = model.UserId,
                ConcertId = model.ConcertId,
                Content = model.Content
            };

            this.db.Comments.Add( comment );
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task< IEnumerable< ListAllCommentsServiceModel > > AllCommentsForConcertAsync( int concertId )
        {
            if ( concertId <= 0 )
            {
                return null;
            }

            var comments = await this.db
                .Comments
                .Where( c => c.ConcertId == concertId )
                .ProjectTo< ListAllCommentsServiceModel >()
                .ToListAsync();

            return comments;
        }

        public async Task< IEnumerable< CheckoutTicketServiceModel > > ListCheckoutAsync( List< int > ids )
        {
            if ( !ids.Any() )
            {
                return null;
            }

            var tickets = await this.db
                .Tickets
                .Where( t => ids.Contains( t.Id ) && t.IsPaid == false )
                .ProjectTo< CheckoutTicketServiceModel >()
                .ToListAsync();

            return tickets;
        }

        public async Task< bool > GetSumToCheckoutAsync( List< int > ids, decimal sum )
        {
            if ( !ids.Any() )
            {
                return false;
            }

            if ( sum <= 0.0m )
            {
                return false;
            }

            var tickets = await this.ListCheckoutAsync( ids );

            if ( !tickets.Any() )
            {
                return false;
            }

            var sumTickets = tickets.Sum( t => t.TicketPrice );

            if ( sumTickets == sum )
            {
                return true;
            }

            return false;
        }

        public async Task< bool > FinalizeOrderAsync( List< int > ids )
        {
            if ( !ids.Any() )
            {
                return false;
            }

            var tickets = await this.ListCheckoutAsync( ids );

            if ( !tickets.Any() )
            {
                return false;
            }

            foreach ( var ticket in tickets )
            {
                var ticketUpdated = await this.db.Tickets.SingleOrDefaultAsync( t => t.Id == ticket.Id );
                if ( ticketUpdated != null )
                {
                    ticketUpdated.IsPaid = true;
                    this.db.Update( ticketUpdated );

                    var concert = this.db.Concerts.SingleOrDefault( c => c.Id == ticketUpdated.ConcertId );
                    concert.TicketsSold += ticketUpdated.Count;

                    this.db.Update( concert );
                }
            }

            await this.db.SaveChangesAsync();
            return true;
        }
    }
}