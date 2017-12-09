using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Services.Organizer.Contracts
{
    public interface IOrganizerConcertService
    {
        Task< IEnumerable< ListAllConcertsServiceModel > > AllAsync();

        Task< bool > CreateAsync( CreateConcertServiceModel concertModel );

        Task< EditConcertServiceModel > GetForEditAsync( int id );

        Task< bool > EditAsync( int id, EditConcertServiceModel editModel );

        Task< List< GetBandsServiceModel > > BandsAsync();
    }
}