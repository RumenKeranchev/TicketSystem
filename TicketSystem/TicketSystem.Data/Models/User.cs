using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TicketSystem.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public List< Ticket > Tickets { get; set; } = new List< Ticket >();
    }
}