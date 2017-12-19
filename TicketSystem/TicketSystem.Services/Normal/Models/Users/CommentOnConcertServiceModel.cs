using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Services.Normal.Models.Users
{
    public class CommentOnConcertServiceModel
    {
        public string UserId { get; set; }

        [ Required ]
        public int ConcertId { get; set; }

        [ Required ]
        public string Content { get; set; }
    }
}