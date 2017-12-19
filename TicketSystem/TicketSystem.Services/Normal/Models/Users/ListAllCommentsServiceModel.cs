using AutoMapper;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class ListAllCommentsServiceModel : IMapFrom< Comment >,IHaveCustomMapping
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public void ConfigureMapping( Profile mapper )
        {
            mapper
                .CreateMap< Comment, ListAllCommentsServiceModel >()
                .ForMember( c => c.Name, cfg => cfg.MapFrom( c => c.User.Name ) );
        }
    }
}