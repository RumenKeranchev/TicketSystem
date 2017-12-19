﻿namespace TicketSystem.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ConcertId { get; set; }

        public Concert Concert { get; set; }

        public string Content { get; set; }
    }
}