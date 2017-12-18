using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Models.Bands;
using TicketSystem.Services.Normal.Models.Bands.Albums;

namespace TicketSystem.Services.Normal.Contracts
{
    public interface IBandService
    {
        Task< IEnumerable< AllBandsServiceModel > > AllAsync();

        Task< BandDetailsServiceModel > DetailsAsync( int id );

        Task< DetailedAlbumListingServiceModel > AlbumDetailsAsync( int id );

        DetailedAlbumListingServiceModel GetAlbumDetailsByTrackAsync( int id );
    }
}