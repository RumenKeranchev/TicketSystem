using System;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Organizer.Models
{
    public class EditConcertServiceModel : IMapFrom< Concert >
    {
        public string Name { get; set; }

        [ Required ]
        [ Display( Name = "Start Date" ) ]
        public DateTime StartDate { get; set; }

        [ Required ]
        [ Display( Name = "End Date" ) ]
        public DateTime EndDate { get; set; }

        [ Required ]
        [ Display( Name = "Max Number of Tickets" ) ]
        [ Range( 0, int.MaxValue ) ]
        public int MaxNumberOfTickets { get; set; }
    }
}