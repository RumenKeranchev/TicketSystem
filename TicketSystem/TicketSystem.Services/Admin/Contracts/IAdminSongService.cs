using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Admin.Models.AlbumsServiceModels;
using TicketSystem.Services.Admin.Models.BandsServiceModels;
using TicketSystem.Services.Admin.Models.SongsServiceModels;

namespace TicketSystem.Services.Admin.Contracts
{
    public interface IAdminSongService
    {
        Task< IEnumerable< SongListingServiceModel > > AllAsync( int page = 1 );

        Task< bool > CreateAsync( CreateSongServiceModel model );

        Task< CreateSongServiceModel > GetByIdAsync( int id );

        Task< bool > EditAsync( int id, CreateSongServiceModel model );

        Task< int > TotalAsync();

        Task< string > GetForDeletionAsync( int id );

        Task< bool > DestroyAsync( int id );

        Task< IEnumerable< BandsWithAlbumsServiceModel > > WithAlbumsAsync();

        Task< bool > CreateAlbumAsync( CreateAblumServiceModel model );

        Task< IEnumerable< GetBandsForAlbumsServiceModel > > BandsAsync();
    }
}