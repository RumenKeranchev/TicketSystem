using System.Threading.Tasks;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Admin.Contracts
{
    public interface IAdminBandService
    {
        Task CreateBand( string name, Genre genre );
    }
}