using AutoMapper;

namespace TicketSystem.Common.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping( Profile mapper );
    }
}