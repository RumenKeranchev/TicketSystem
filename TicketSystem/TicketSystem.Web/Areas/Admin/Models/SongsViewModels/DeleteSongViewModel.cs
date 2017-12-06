using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Web.Areas.Admin.Models.SongsViewModels
{
    public class DeleteSongViewModel
    {
        [ Required ]
        public int Id { get; set; }

        public string SongName { get; set; }
    }
}