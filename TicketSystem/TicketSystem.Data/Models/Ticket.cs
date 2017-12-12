using System;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [ Required ]
        public decimal Price { get; set; }

        [ Required ]
        public int Count { get; set; }

        [ Required ]
        public string UserId { get; set; }

        public User User { get; set; }

        [ Required ]
        public int ConcertId { get; set; }

        public Concert Concert { get; set; }

        public bool IsPaid { get; set; }
    }
}