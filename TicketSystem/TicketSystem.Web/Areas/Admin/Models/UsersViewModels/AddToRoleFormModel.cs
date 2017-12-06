using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Web.Areas.Admin.Models.UsersViewModels
{
    public class AddToRoleFormModel
    {
        [Required]
        public string UserId { get; set; }

        public string Role { get; set; }

    }
}