using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TicketSystem.Services.Admin.Contracts;
using TicketSystem.Web.Areas.Admin.Models.AlbumsViewModels;
using TicketSystem.Web.Areas.Admin.Models.SongsViewModels;

namespace TicketSystem.Web.Areas.Admin.Controllers
{
    public class SongsAdminController : BaseAdminController
    {
        private readonly IAdminSongService songService;

        public SongsAdminController( IAdminSongService songService )
        {
            this.songService = songService;
        }

        public async Task< IActionResult > Index( int page = 1 )
        {
            var songs = await this.songService.AllAsync( page );
            var nuberOfSongs = await this.songService.TotalAsync();

            return this.View( new IndexViewModel
            {
                Songs = songs,
                TotalSongs = nuberOfSongs,
                CurrentPage = page
            } );
        }

        public async Task< IActionResult > Create()
        {
            var bands = await this.songService.WithAlbumsAsync();

            return this.View( new CreateSongViewModel { Bands = bands } );
        }

        [ HttpPost ]
        public async Task< IActionResult > Create( CreateSongViewModel songModel )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( songModel );
            }

            if ( songModel == null )
            {
                return this.BadRequest();
            }

            var success = await this.songService.CreateAsync( songModel.Song );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }

        public async Task< IActionResult > Edit( int id )
        {
            var song = await this.songService.GetByIdAsync( id );

            if ( song == null )
            {
                return this.BadRequest();
            }

            var bands = await this.songService.WithAlbumsAsync();

            if ( bands == null )
            {
                return this.BadRequest();
            }

            return this.View( new CreateSongViewModel { Song = song, Bands = bands } );
        }

        [ HttpPost ]
        public async Task< IActionResult > Edit( int id, CreateSongViewModel model )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( model );
            }

            var success = await this.songService.EditAsync( id, model.Song );

            if ( !success )
            {
                return this.BadRequest();
            }

            return this.RedirectToAction( nameof( this.Index ) );
        }

        public async Task< IActionResult > Delete( int id )
        {
            return this.View( new DeleteSongViewModel
            {
                Id = id,
                SongName = await this.songService.GetForDeletionAsync( id )
            } );
        }

        public async Task< IActionResult > Destroy( DeleteSongViewModel deleteSong )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.BadRequest();
            }

            await this.songService.DestroyAsync( deleteSong.Id );

            return this.RedirectToAction( nameof( this.Index ) );
        }

        public async Task< IActionResult > CreateAlbum()
        {
            return this.View( new CreateAlbumViewModel
            {
                Bands = await this.songService.BandsAsync()
            } );
        }

        [ HttpPost ]
        public async Task< IActionResult > CreateAlbum( CreateAlbumViewModel albumView )
        {
            if ( !this.ModelState.IsValid )
            {
                return this.View( albumView );
            }

            var success = await this.songService.CreateAlbumAsync( albumView.Album );

            if ( success )
            {
                return this.RedirectToAction( "Index", "SongsAdmin" );
            }

            return this.BadRequest();
        }
    }
}