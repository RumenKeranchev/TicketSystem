using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Organizer.Models;

namespace TicketSystem.Services.Organizer.Contracts
{
    public interface IOrganizerConcertService
    {
        Task< IEnumerable< ListAllConcertsServiceModel > > All();

        Task< bool > Create( CreateConcertServiceModel concertModel );
    }
}