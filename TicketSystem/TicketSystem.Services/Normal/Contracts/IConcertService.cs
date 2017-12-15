using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Models.Concerts;

namespace TicketSystem.Services.Normal.Contracts
{
    public interface IConcertService
    {
        Task< ConcertListingServiceModel > DetailsAsync( int id );

        Task< IEnumerable< ListPreviousConcertsServiceModel > > GetPrevious();
    }
}