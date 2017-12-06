using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Common.Contstants;
using TicketSystem.Data;
using TicketSystem.Data.Models;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Services.Admin.Models.AlbumsServiceModels;
using TicketSystem.Services.Admin.Models.BandsServiceModels;
using TicketSystem.Services.Admin.Models.SongsServiceModels;

namespace TicketSystem.Services.Admin.Implementations
{
    public class AdminSongService : IAdminSongService
    {
        private readonly TicketSystemDbContext db;

        public AdminSongService( TicketSystemDbContext db )
        {
            this.db = db;
        }

        public async Task< IEnumerable< SongListingServiceModel > > AllAsync( int page = 1 )
        {
            var songs = await this.db
                .Songs
                .Include( s => s.Album )
                .OrderBy( s => s.Id )
                .Skip( ( page - 1 ) * WebConstants.MaxItemsPerPage )
                .Take( WebConstants.MaxItemsPerPage )
                .ProjectTo< SongListingServiceModel >()
                .ToListAsync();

            return songs;
        }

        public async Task< bool > CreateAsync( CreateSongServiceModel model )
        {
            if ( this.db.Songs.Any( s => s.Name == model.Name && s.Genre == model.Genre ) || model == null )
            {
                return false;
            }

            var song = new Song
            {
                Name = model.Name,
                Genre = model.Genre,
                UrlId = model.UrlId,
                AlbumId = model.AlbumId
            };

            this.db.Songs.Add( song );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task< CreateSongServiceModel > GetByIdAsync( int id )
        {
            var song = await this.db
                .Songs
                .Where( s => s.Id == id )
                .ProjectTo< CreateSongServiceModel >()
                .FirstOrDefaultAsync();

            return song;
        }

        public async Task< bool > EditAsync( int id, CreateSongServiceModel model )
        {
            if ( model == null )
            {
                return false;
            }
            var song = await this.db.Songs.FirstOrDefaultAsync( s => s.Id == id );

            if ( song == null )
            {
                return false;
            }

            song.Name = model.Name;
            song.AlbumId = model.AlbumId;
            song.Genre = model.Genre;
            song.UrlId = model.UrlId;

            this.db.Update( song );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task< int > TotalAsync()
        {
            var songs = await this.db
                .Songs
                .CountAsync();

            return songs;
        }

        public async Task< string > GetForDeletionAsync( int id )
        {
            var songName = await this.db
                .Songs
                .Where( s => s.Id == id )
                .Select( s => s.Name )
                .FirstOrDefaultAsync();

            return songName;
        }

        public async Task< bool > DestroyAsync( int id )
        {
            if ( id == 0 )
            {
                return false;
            }

            var song = await this.db.Songs.FirstOrDefaultAsync( s => s.Id == id );

            if ( song == null )
            {
                return false;
            }

            this.db.Songs.Remove( song );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task< IEnumerable< BandsWithAlbumsServiceModel > > WithAlbumsAsync()
        {
            var bands = await this.db
                .Bands
                .OrderBy( b => b.Name )
                .ProjectTo< BandsWithAlbumsServiceModel >()
                .ToListAsync();

            return bands;
        }

        public async Task<bool> CreateAlbumAsync( CreateAblumServiceModel model )
        {
            if ( model == null )
            {
                return false;
            }

            var album = new Album
            {
                BandId = model.BandId,
                Genre = model.Genre,
                Name = model.Name,
                ImageUrl = model.ImageUrl
            };

            this.db.Albums.Add( album );
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GetBandsForAlbumsServiceModel>> BandsAsync()
        {
            var bands = await this.db
                .Bands
                .ProjectTo<GetBandsForAlbumsServiceModel>()
                .ToListAsync();

            return bands;
        }
    }
}