using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Services.Organizer.Contracts
{
    public interface IOrganizerService
    {
        Task< IEnumerable< ListAllConcertsServiceModel > > AllAsync();

        Task< bool > CreateAsync( CreateConcertServiceModel concertModel );

        Task< EditConcertServiceModel > GetForEditAsync( int id );

        Task< bool > EditAsync( int id, EditConcertServiceModel editModel );

        Task< List< GetBandsServiceModel > > BandsAsync();

        Task< bool > Delete( int id );
    }
}