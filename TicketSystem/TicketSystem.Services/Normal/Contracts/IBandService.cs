using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Services.Normal.Models.Bands;

namespace TicketSystem.Services.Normal.Contracts
{
    public interface IBandService
    {
        Task< IEnumerable< AllBandsServiceModel > > AllAsync();
    }
}